using Dapper;
using SistemaDeAgendamento.Database;
using System;
using System.Collections.Generic;
using System.Data;

namespace SistemaDeAgendamento.Repositories
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public override string ToString() => FullName;
    }

    public class BarberDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public override string ToString() => FullName;
    }

    public class ScheduleSlot
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }

    public static class AppointmentRepository
    {
        public static IEnumerable<ClientDto> GetClients()
        {
            using (IDbConnection db = DbConnection.Create())
                return db.Query<ClientDto>(@"
                    SELECT id,
                           first_name || ' ' || last_name AS FullName
                    FROM   clients
                    ORDER  BY first_name, last_name");
        }

        public static IEnumerable<BarberDto> GetBarbers()
        {
            using (IDbConnection db = DbConnection.Create())
                return db.Query<BarberDto>(@"
                    SELECT id,
                           first_name || ' ' || last_name AS FullName
                    FROM   barbers
                    ORDER  BY first_name, last_name");
        }

        public static IEnumerable<ServiceDto> GetServices()
        {
            using (IDbConnection db = DbConnection.Create())
                return db.Query<ServiceDto>(@"
                    SELECT id, name, price
                    FROM   services
                    WHERE  active = TRUE
                    ORDER  BY name");
        }

        // Returns free 30-min slots for a barber on a given date
        public static IEnumerable<string> GetAvailableSlots(int barberId, DateTime date)
        {
            using (IDbConnection db = DbConnection.Create())
            {
                // 1 — Check if barber works that day (0=Sun … 6=Sat)
                var schedule = db.QueryFirstOrDefault<ScheduleSlot>(@"
                    SELECT start_time AS start, end_time AS ""end""
                    FROM   barber_schedules
                    WHERE  barber_id   = @BarberId
                      AND  day_of_week = @Dow",
                    new { BarberId = barberId, Dow = (int)date.DayOfWeek });

                if (schedule == default) yield break;   // day off

                // 2 — Already booked slots
                var booked = new HashSet<string>(
                    db.Query<string>(@"
                        SELECT TO_CHAR(appointment_time, 'HH24:MI')
                        FROM   appointments
                        WHERE  barber_id        = @BarberId
                          AND  appointment_date = @Date
                          AND  status          <> 'cancelled'",
                        new { BarberId = barberId, Date = date.Date }));

                // 3 — Build slots
                var current = schedule.Start;
                while (current < schedule.End)
                {
                    var label = current.ToString(@"hh\:mm");
                    if (!booked.Contains(label)) yield return label;
                    current = current.Add(TimeSpan.FromMinutes(30));
                }
            }
        }

        // Saves the appointment + service inside a single transaction
        public static void SaveAppointment(
            int barberId,
            int clientId,
            int serviceId,
            decimal servicePrice,
            DateTime appointmentDate,
            string timeSlot,
            string notes = null)
        {
            using (IDbConnection db = DbConnection.Create())
            {
                db.Open();
                using (var tx = db.BeginTransaction())
                {
                    try
                    {
                        var appointmentId = db.ExecuteScalar<int>(@"
                            INSERT INTO appointments
                                (barber_id, client_id, appointment_date,
                                 appointment_time, status, notes)
                            VALUES
                                (@BarberId, @ClientId, @Date,
                                 @Time::TIME, 'scheduled', @Notes)
                            RETURNING id",
                            new
                            {
                                BarberId = barberId,
                                ClientId = clientId,
                                Date = appointmentDate.Date,
                                Time = timeSlot,
                                Notes = notes
                            }, tx);

                        db.Execute(@"
                            INSERT INTO appointment_services
                                (appointment_id, service_id, unit_price)
                            VALUES
                                (@AppointmentId, @ServiceId, @Price)",
                            new
                            {
                                AppointmentId = appointmentId,
                                ServiceId = serviceId,
                                Price = servicePrice
                            }, tx);

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
