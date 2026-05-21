namespace SistemaDeAgendamento.Forms
{
    partial class FormService
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
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.SuspendLayout();

            // Form
            this.Text = "Gerenciar Serviços";
            this.Size = new System.Drawing.Size(700, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FormService_Load);

            int lx = 20;
            int cx = 160;
            int cw = 200;

            // Title
            this.lblTitle.Text = "Gerenciar Serviços";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblTitle.Location = new System.Drawing.Point(lx, 16);
            this.lblTitle.Size = new System.Drawing.Size(400, 32);

            // Grid
            this.dgvServices.Location = new System.Drawing.Point(lx, 60);
            this.dgvServices.Size = new System.Drawing.Size(645, 200);
            this.dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServices.MultiSelect = false;
            this.dgvServices.ReadOnly = true;
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.AllowUserToDeleteRows = false;
            this.dgvServices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvServices.RowHeadersVisible = false;
            this.dgvServices.BackgroundColor = System.Drawing.Color.White;
            this.dgvServices.SelectionChanged += new System.EventHandler(this.dgvServices_SelectionChanged);

            // Separator line
            var sep = new System.Windows.Forms.Label();
            sep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            sep.Location = new System.Drawing.Point(lx, 275);
            sep.Size = new System.Drawing.Size(645, 2);

            // Name
            this.lblName.Text = "Nome";
            this.lblName.Location = new System.Drawing.Point(lx, 295);
            this.lblName.Size = new System.Drawing.Size(130, 26);
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtName.Location = new System.Drawing.Point(cx, 295);
            this.txtName.Size = new System.Drawing.Size(cw, 26);
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.MaxLength = 100;

            // Description
            this.lblDescription.Text = "Descrição";
            this.lblDescription.Location = new System.Drawing.Point(lx, 335);
            this.lblDescription.Size = new System.Drawing.Size(130, 26);
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtDescription.Location = new System.Drawing.Point(cx, 335);
            this.txtDescription.Size = new System.Drawing.Size(cw, 60);
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Price
            this.lblPrice.Text = "Valor (R$)";
            this.lblPrice.Location = new System.Drawing.Point(lx, 410);
            this.lblPrice.Size = new System.Drawing.Size(130, 26);
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtPrice.Location = new System.Drawing.Point(cx, 410);
            this.txtPrice.Size = new System.Drawing.Size(100, 26);
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Active
            this.chkActive.Text = "Serviço ativo";
            this.chkActive.Location = new System.Drawing.Point(cx, 448);
            this.chkActive.Size = new System.Drawing.Size(150, 24);
            this.chkActive.Checked = true;

            // Buttons
            this.btnNew.Text = "Novo";
            this.btnNew.Location = new System.Drawing.Point(lx, 486);
            this.btnNew.Size = new System.Drawing.Size(90, 36);
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);

            this.btnSave.Text = "Salvar";
            this.btnSave.Location = new System.Drawing.Point(120, 486);
            this.btnSave.Size = new System.Drawing.Size(90, 36);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 130, 60);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnDelete.Text = "Excluir";
            this.btnDelete.Location = new System.Drawing.Point(220, 486);
            this.btnDelete.Size = new System.Drawing.Size(90, 36);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(180, 30, 30);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnClose.Text = "Fechar";
            this.btnClose.Location = new System.Drawing.Point(575, 486);
            this.btnClose.Size = new System.Drawing.Size(90, 36);
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblTitle,
                dgvServices,
                sep,
                lblName,        txtName,
                lblDescription, txtDescription,
                lblPrice,       txtPrice,
                chkActive,
                btnNew, btnSave, btnDelete, btnClose
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}