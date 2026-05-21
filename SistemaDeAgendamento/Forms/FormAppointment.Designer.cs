namespace SistemaDeAgendamento.Forms
{
    partial class FormAppointment
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
            this.lblClient = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblBarber = new System.Windows.Forms.Label();
            this.cmbBarber = new System.Windows.Forms.ComboBox();
            this.lblService = new System.Windows.Forms.Label();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.lblNoSlots = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Form
            this.Text = "Novo Agendamento";
            this.Size = new System.Drawing.Size(440, 510);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FormAppointment_Load);

            // Layout constants
            int lx = 20;    // label x
            int cx = 160;   // control x
            int cw = 240;   // control width

            // Title
            this.lblTitle.Text = "Novo Agendamento";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.lblTitle.Location = new System.Drawing.Point(lx, 16);
            this.lblTitle.Size = new System.Drawing.Size(380, 32);

            // Client
            this.lblClient.Text = "Cliente";
            this.lblClient.Location = new System.Drawing.Point(lx, 68);
            this.lblClient.Size = new System.Drawing.Size(130, 26);
            this.lblClient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.cmbClient.Location = new System.Drawing.Point(cx, 68);
            this.cmbClient.Size = new System.Drawing.Size(cw, 26);
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // Barber
            this.lblBarber.Text = "Barbeiro";
            this.lblBarber.Location = new System.Drawing.Point(lx, 108);
            this.lblBarber.Size = new System.Drawing.Size(130, 26);
            this.lblBarber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.cmbBarber.Location = new System.Drawing.Point(cx, 108);
            this.cmbBarber.Size = new System.Drawing.Size(cw, 26);
            this.cmbBarber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBarber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBarber.SelectedIndexChanged += new System.EventHandler(this.cmbBarber_SelectedIndexChanged);

            // Service
            this.lblService.Text = "Serviço";
            this.lblService.Location = new System.Drawing.Point(lx, 148);
            this.lblService.Size = new System.Drawing.Size(130, 26);
            this.lblService.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.cmbService.Location = new System.Drawing.Point(cx, 148);
            this.cmbService.Size = new System.Drawing.Size(cw, 26);
            this.cmbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbService.SelectedIndexChanged += new System.EventHandler(this.cmbService_SelectedIndexChanged);

            // Price hint
            this.lblPrice.Text = "Valor: —";
            this.lblPrice.Location = new System.Drawing.Point(cx, 178);
            this.lblPrice.Size = new System.Drawing.Size(cw, 20);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(0, 130, 60);
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);

            // Date
            this.lblDate.Text = "Data";
            this.lblDate.Location = new System.Drawing.Point(lx, 208);
            this.lblDate.Size = new System.Drawing.Size(130, 26);
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.dtpDate.Location = new System.Drawing.Point(cx, 208);
            this.dtpDate.Size = new System.Drawing.Size(cw, 26);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);

            // Time
            this.lblTime.Text = "Horário";
            this.lblTime.Location = new System.Drawing.Point(lx, 248);
            this.lblTime.Size = new System.Drawing.Size(130, 26);
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.cmbTime.Location = new System.Drawing.Point(cx, 248);
            this.cmbTime.Size = new System.Drawing.Size(120, 26);
            this.cmbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.lblNoSlots.Text = "Sem horários disponíveis para este dia.";
            this.lblNoSlots.Location = new System.Drawing.Point(cx, 278);
            this.lblNoSlots.Size = new System.Drawing.Size(cw, 20);
            this.lblNoSlots.ForeColor = System.Drawing.Color.Firebrick;
            this.lblNoSlots.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNoSlots.Visible = false;

            // Notes
            this.lblNotes.Text = "Observações";
            this.lblNotes.Location = new System.Drawing.Point(lx, 315);
            this.lblNotes.Size = new System.Drawing.Size(130, 26);
            this.lblNotes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.txtNotes.Location = new System.Drawing.Point(cx, 315);
            this.txtNotes.Size = new System.Drawing.Size(cw, 60);
            this.txtNotes.Multiline = true;
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Buttons
            this.btnSave.Text = "Confirmar";
            this.btnSave.Location = new System.Drawing.Point(cx, 400);
            this.btnSave.Size = new System.Drawing.Size(115, 36);
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 130, 60);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "Cancelar";
            this.btnCancel.Location = new System.Drawing.Point(cx + 125, 400);
            this.btnCancel.Size = new System.Drawing.Size(115, 36);
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblTitle,
                lblClient,  cmbClient,
                lblBarber,  cmbBarber,
                lblService, cmbService, lblPrice,
                lblDate,    dtpDate,
                lblTime,    cmbTime,    lblNoSlots,
                lblNotes,   txtNotes,
                btnSave,    btnCancel
            });

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label lblBarber;
        private System.Windows.Forms.ComboBox cmbBarber;
        private System.Windows.Forms.Label lblService;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.Label lblNoSlots;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}