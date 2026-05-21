using SistemaDeAgendamento.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeAgendamento.Forms
{
    public partial class FormAppointment : Form
    {
        public FormAppointment()
        {
            InitializeComponent();
        }

        // ── Load ──────────────────────────────────────────────────────────────

        private void FormAppointment_Load(object sender, EventArgs e)
        {
            try
            {
                dtpDate.MinDate = DateTime.Today;
                dtpDate.Value = DateTime.Today;

                cmbClient.DataSource = AppointmentRepository.GetClients().ToList();
                cmbBarber.DataSource = AppointmentRepository.GetBarbers().ToList();
                cmbService.DataSource = AppointmentRepository.GetServices().ToList();

                LoadAvailableSlots();
            }
            catch (Exception ex)
            {
                ShowError("Erro ao carregar dados", ex);
            }
        }

        // ── Slots ─────────────────────────────────────────────────────────────

        private void LoadAvailableSlots()
        {
            cmbTime.Items.Clear();
            lblNoSlots.Visible = false;

            var barber = cmbBarber.SelectedItem as BarberDto;

            if (barber == null) return;

            var slots = AppointmentRepository
                            .GetAvailableSlots(barber.Id, dtpDate.Value)
                            .ToList();

            if (slots.Count == 0)
            {
                lblNoSlots.Visible = true;
                return;
            }

            cmbTime.Items.AddRange(slots.ToArray<object>());
            cmbTime.SelectedIndex = 0;
        }

        private void cmbBarber_SelectedIndexChanged(object sender, EventArgs e) => LoadAvailableSlots();
        private void dtpDate_ValueChanged(object sender, EventArgs e) => LoadAvailableSlots();

        // ── Service price hint ────────────────────────────────────────────────

        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            var svc = cmbService.SelectedItem as ServiceDto;
            if (svc != null)
                lblPrice.Text = $"Valor: R$ {svc.Price:F2}";
        }

        // ── Save ──────────────────────────────────────────────────────────────

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsFormValid()) return;

            try
            {
                var client = (ClientDto)cmbClient.SelectedItem;
                var barber = (BarberDto)cmbBarber.SelectedItem;
                var service = (ServiceDto)cmbService.SelectedItem;

                AppointmentRepository.SaveAppointment(
                    barberId: barber.Id,
                    clientId: client.Id,
                    serviceId: service.Id,
                    servicePrice: service.Price,
                    appointmentDate: dtpDate.Value,
                    timeSlot: cmbTime.SelectedItem.ToString(),
                    notes: txtNotes.Text.Trim()
                );

                MessageBox.Show(
                    $"Agendamento confirmado!\n\n" +
                    $"Cliente:  {client.FullName}\n" +
                    $"Barbeiro: {barber.FullName}\n" +
                    $"Serviço:  {service.Name}  (R$ {service.Price:F2})\n" +
                    $"Data:     {dtpDate.Value:dd/MM/yyyy} às {cmbTime.SelectedItem}",
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ResetForm();
            }
            catch (Exception ex)
            {
                ShowError("Erro ao salvar agendamento", ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        // ── Helpers ───────────────────────────────────────────────────────────

        private bool IsFormValid()
        {
            if (cmbClient.SelectedItem == null) return Warn("Selecione um cliente.");
            if (cmbBarber.SelectedItem == null) return Warn("Selecione um barbeiro.");
            if (cmbService.SelectedItem == null) return Warn("Selecione um serviço.");
            if (cmbTime.SelectedItem == null) return Warn("Selecione um horário disponível.");
            return true;
        }

        private bool Warn(string msg)
        {
            MessageBox.Show(msg, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private void ShowError(string context, Exception ex) =>
            MessageBox.Show($"{context}:\n{ex.Message}", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ResetForm()
        {
            dtpDate.Value = DateTime.Today;
            cmbClient.SelectedIndex = 0;
            cmbBarber.SelectedIndex = 0;
            cmbService.SelectedIndex = 0;
            txtNotes.Clear();
            LoadAvailableSlots();
        }
    }
}
