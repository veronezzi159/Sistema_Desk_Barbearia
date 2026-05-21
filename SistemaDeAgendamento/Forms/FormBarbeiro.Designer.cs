namespace SistemaDeAgendamento.Forms
{
    partial class FormBarbeiro
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvBarbeiros = new System.Windows.Forms.DataGridView();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblSobrenome = new System.Windows.Forms.Label();
            this.txtSobrenome = new System.Windows.Forms.TextBox();
            this.lblCpf = new System.Windows.Forms.Label();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.TextBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarbeiros)).BeginInit();
            this.SuspendLayout();

            // Form
            this.Text = "Cadastro de Barbeiros";
            this.Size = new System.Drawing.Size(700, 530);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FormBarbeiro_Load);

            int lx = 20;
            int cx = 160;
            int cw = 200;

            // Title
            this.lblTitle.Text = "Cadastro de Barbeiros";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblTitle.Location = new System.Drawing.Point(lx, 16);
            this.lblTitle.Size = new System.Drawing.Size(400, 32);

            // Grid
            this.dgvBarbeiros.Location = new System.Drawing.Point(lx, 60);
            this.dgvBarbeiros.Size = new System.Drawing.Size(645, 190);
            this.dgvBarbeiros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBarbeiros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarbeiros.MultiSelect = false;
            this.dgvBarbeiros.ReadOnly = true;
            this.dgvBarbeiros.AllowUserToAddRows = false;
            this.dgvBarbeiros.AllowUserToDeleteRows = false;
            this.dgvBarbeiros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvBarbeiros.RowHeadersVisible = false;
            this.dgvBarbeiros.BackgroundColor = System.Drawing.Color.White;
            this.dgvBarbeiros.SelectionChanged += new System.EventHandler(this.dgvBarbeiros_SelectionChanged);

            // Separator
            var sep = new System.Windows.Forms.Label();
            sep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sep.Location = new System.Drawing.Point(lx, 262);
            sep.Size = new System.Drawing.Size(645, 2);

            // Nome
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new System.Drawing.Point(lx, 280);
            this.lblNome.Size = new System.Drawing.Size(130, 26);
            this.lblNome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtNome.Location = new System.Drawing.Point(cx, 280);
            this.txtNome.Size = new System.Drawing.Size(cw, 26);
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.MaxLength = 100;

            // Sobrenome
            this.lblSobrenome.Text = "Sobrenome";
            this.lblSobrenome.Location = new System.Drawing.Point(lx, 318);
            this.lblSobrenome.Size = new System.Drawing.Size(130, 26);
            this.lblSobrenome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtSobrenome.Location = new System.Drawing.Point(cx, 318);
            this.txtSobrenome.Size = new System.Drawing.Size(cw, 26);
            this.txtSobrenome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSobrenome.MaxLength = 100;

            // CPF
            this.lblCpf.Text = "CPF";
            this.lblCpf.Location = new System.Drawing.Point(lx, 356);
            this.lblCpf.Size = new System.Drawing.Size(130, 26);
            this.lblCpf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtCpf.Location = new System.Drawing.Point(cx, 356);
            this.txtCpf.Size = new System.Drawing.Size(150, 26);
            this.txtCpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCpf.MaxLength = 11;

            // Telefone
            this.lblTelefone.Text = "Telefone";
            this.lblTelefone.Location = new System.Drawing.Point(lx, 394);
            this.lblTelefone.Size = new System.Drawing.Size(130, 26);
            this.lblTelefone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtTelefone.Location = new System.Drawing.Point(cx, 394);
            this.txtTelefone.Size = new System.Drawing.Size(150, 26);
            this.txtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefone.MaxLength = 20;

            // Buttons
            this.btnNovo.Text = "Novo";
            this.btnNovo.Location = new System.Drawing.Point(lx, 444);
            this.btnNovo.Size = new System.Drawing.Size(90, 36);
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);

            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.Location = new System.Drawing.Point(120, 444);
            this.btnSalvar.Size = new System.Drawing.Size(90, 36);
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(0, 130, 60);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.Location = new System.Drawing.Point(220, 444);
            this.btnExcluir.Size = new System.Drawing.Size(90, 36);
            this.btnExcluir.BackColor = System.Drawing.Color.FromArgb(180, 30, 30);
            this.btnExcluir.ForeColor = System.Drawing.Color.White;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.FlatAppearance.BorderSize = 0;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);

            this.btnFechar.Text = "Fechar";
            this.btnFechar.Location = new System.Drawing.Point(575, 444);
            this.btnFechar.Size = new System.Drawing.Size(90, 36);
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblTitle,
                dgvBarbeiros,
                sep,
                lblNome,      txtNome,
                lblSobrenome, txtSobrenome,
                lblCpf,       txtCpf,
                lblTelefone,  txtTelefone,
                btnNovo, btnSalvar, btnExcluir, btnFechar
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgvBarbeiros)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvBarbeiros;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblSobrenome;
        private System.Windows.Forms.TextBox txtSobrenome;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtTelefone;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnFechar;
    }
}