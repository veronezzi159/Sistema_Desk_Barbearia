namespace SistemaDeAgendamento.Forms
{
    partial class formMainMenu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnBarbeiros;
        private System.Windows.Forms.Button btnServicos;
        private System.Windows.Forms.Button btnAgendamentos;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnBarbeiros = new System.Windows.Forms.Button();
            this.btnServicos = new System.Windows.Forms.Button();
            this.btnAgendamentos = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // btnClientes
            this.btnClientes.Location = new System.Drawing.Point(50, 30);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(200, 50);
            this.btnClientes.Text = "Gerenciar Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);

            // btnBarbeiros
            this.btnBarbeiros.Location = new System.Drawing.Point(50, 100);
            this.btnBarbeiros.Name = "btnBarbeiros";
            this.btnBarbeiros.Size = new System.Drawing.Size(200, 50);
            this.btnBarbeiros.Text = "Gerenciar Barbeiros";
            this.btnBarbeiros.UseVisualStyleBackColor = true;
            this.btnBarbeiros.Click += new System.EventHandler(this.btnBarbeiros_Click);

            // btnServicos
            this.btnServicos.Location = new System.Drawing.Point(50, 170);
            this.btnServicos.Name = "btnServicos";
            this.btnServicos.Size = new System.Drawing.Size(200, 50);
            this.btnServicos.Text = "Gerenciar Serviços";
            this.btnServicos.UseVisualStyleBackColor = true;
            this.btnServicos.Click += new System.EventHandler(this.btnServicos_Click);

            // btnAgendamentos
            this.btnAgendamentos.Location = new System.Drawing.Point(50, 240);
            this.btnAgendamentos.Name = "btnAgendamentos";
            this.btnAgendamentos.Size = new System.Drawing.Size(200, 50);
            this.btnAgendamentos.Text = "Agendamentos";
            this.btnAgendamentos.UseVisualStyleBackColor = true;
            this.btnAgendamentos.Click += new System.EventHandler(this.btnAgendamentos_Click);

            // formMainMenu
            this.ClientSize = new System.Drawing.Size(300, 330);
            this.Controls.Add(this.btnAgendamentos);
            this.Controls.Add(this.btnServicos);
            this.Controls.Add(this.btnBarbeiros);
            this.Controls.Add(this.btnClientes);
            this.Name = "formMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal - Barbearia";
            this.ResumeLayout(false);
        }
    }
}