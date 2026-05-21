using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SistemaDeAgendamento.Database;

namespace SistemaDeAgendamento.Repositories
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public override string ToString() => Name;
    }

    public static class ServiceRepository
    {
        public static IEnumerable<ServiceDto> GetAll()
        {
            using (IDbConnection db = DbConnection.Create())
                return db.Query<ServiceDto>(@"
                    SELECT id, name, description, price, active
                    FROM   services
                    ORDER  BY name");
        }

        public static void Insert(ServiceDto service)
        {
            using (IDbConnection db = DbConnection.Create())
                db.Execute(@"
                    INSERT INTO services (name, description, price, active)
                    VALUES (@Name, @Description, @Price, @Active)",
                    service);
        }

        public static void Update(ServiceDto service)
        {
            using (IDbConnection db = DbConnection.Create())
                db.Execute(@"
                    UPDATE services
                    SET    name        = @Name,
                           description = @Description,
                           price       = @Price,
                           active      = @Active
                    WHERE  id = @Id",
                    service);
        }

        public static void Delete(int id)
        {
            using (IDbConnection db = DbConnection.Create())
                db.Execute("DELETE FROM services WHERE id = @Id", new { Id = id });
        }
    }
}
