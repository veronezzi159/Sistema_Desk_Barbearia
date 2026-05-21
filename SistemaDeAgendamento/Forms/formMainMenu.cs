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
    public partial class formMainMenu : Form
    {
        public formMainMenu()
        {
            InitializeComponent();
        }

        // Botão para abrir a tela de Clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormPessoa frmClient = new FormPessoa();
            frmClient.ShowDialog();
        }

        // Botão para abrir a tela de Barbeiros
        private void btnBarbeiros_Click(object sender, EventArgs e)
        {
            FormBarbeiro frmBarber = new FormBarbeiro();
            frmBarber.ShowDialog();
        }

        // Botão para abrir a tela de Serviços
        private void btnServicos_Click(object sender, EventArgs e)
        {
            var frmService = new FormService();
            frmService.ShowDialog();
        }

        // Botão para abrir a tela de Agendamentos
        private void btnAgendamentos_Click(object sender, EventArgs e)
        {
            var frmAppointment = new FormAppointment();
            frmAppointment.ShowDialog();
        }
    }
}