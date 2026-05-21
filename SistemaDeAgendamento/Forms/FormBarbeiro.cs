using System;
using System.Windows.Forms;
using SistemaDeAgendamento.Models;
using SistemaDeAgendamento.Repositories;

namespace SistemaDeAgendamento.Forms
{
    public partial class FormBarbeiro : Form
    {
        private readonly BarbeiroRepository _repositorio = new BarbeiroRepository();
        private Barbeiro _barbeiroAtual = new Barbeiro();

        private ComboBox cboBarbeiros;
        private TextBox txtNome;
        private TextBox txtCpf;
        private TextBox txtTelefone;
        private DateTimePicker dtpAdmissao;
        private CheckBox chkAtivo;
        private ComboBox cboCategoria;
        private ListBox lstEspecialidades;
        private Button btnAddEsp;
        private Button btnRemEsp;
        private Button btnSalvar;
        private Button btnExcluir;
        private Button btnNovo;

        public FormBarbeiro()
        {
            InitializeComponent();
            MontarTela();
            CarregarComboBarbeiros();
            PreencherCategorias();
        }

        private void MontarTela()
        {
            this.Text = "Cadastro de Barbeiros";
            this.Width = 660;
            this.Height = 520;

            CriarLabel("Barbeiro cadastrado:", 20, 15);
            cboBarbeiros = new ComboBox { Left = 20, Top = 35, Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };
            cboBarbeiros.SelectedIndexChanged += CboBarbeiros_SelectedIndexChanged;

            int x = 20;
            CriarLabel("Nome:", x, 75);
            txtNome = new TextBox { Left = x, Top = 93, Width = 300 };

            CriarLabel("CPF:", x, 125);
            txtCpf = new TextBox { Left = x, Top = 143, Width = 300 };

            CriarLabel("Telefone:", x, 175);
            txtTelefone = new TextBox { Left = x, Top = 193, Width = 300 };

            CriarLabel("Admissão:", x, 225);
            dtpAdmissao = new DateTimePicker { Left = x, Top = 243, Width = 300, Format = DateTimePickerFormat.Short };

            chkAtivo = new CheckBox { Left = x, Top = 283, Width = 120, Text = "Ativo", Checked = true };

            CriarLabel("Especialidade (categoria):", 360, 75);
            cboCategoria = new ComboBox { Left = 360, Top = 95, Width = 200, DropDownStyle = ComboBoxStyle.DropDown };
            btnAddEsp = new Button { Left = 565, Top = 94, Width = 60, Text = "Add" };
            btnAddEsp.Click += BtnAddEsp_Click;

            lstEspecialidades = new ListBox { Left = 360, Top = 130, Width = 265, Height = 200 };
            btnRemEsp = new Button { Left = 360, Top = 335, Width = 120, Text = "Remover" };
            btnRemEsp.Click += BtnRemEsp_Click;

            btnSalvar = new Button { Left = 20, Top = 400, Width = 100, Text = "Salvar" };
            btnExcluir = new Button { Left = 130, Top = 400, Width = 100, Text = "Excluir" };
            btnNovo = new Button { Left = 240, Top = 400, Width = 100, Text = "Novo" };
            btnSalvar.Click += BtnSalvar_Click;
            btnExcluir.Click += BtnExcluir_Click;
            btnNovo.Click += (s, e) => NovoBarbeiro();

            this.Controls.Add(cboBarbeiros);
            this.Controls.Add(txtNome);
            this.Controls.Add(txtCpf);
            this.Controls.Add(txtTelefone);
            this.Controls.Add(dtpAdmissao);
            this.Controls.Add(chkAtivo);
            this.Controls.Add(cboCategoria);
            this.Controls.Add(btnAddEsp);
            this.Controls.Add(lstEspecialidades);
            this.Controls.Add(btnRemEsp);
            this.Controls.Add(btnSalvar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnNovo);
        }

        private void CriarLabel(string texto, int left, int top)
        {
            var label = new Label { Left = left, Top = top, Width = 250, Text = texto };
            this.Controls.Add(label);
        }

        private void PreencherCategorias()
        {
            cboCategoria.Items.Add("Corte masculino");
            cboCategoria.Items.Add("Barba");
            cboCategoria.Items.Add("Sobrancelha");
            cboCategoria.Items.Add("Corte degradê");
            cboCategoria.Items.Add("Pigmentação");
            cboCategoria.Items.Add("Hidratação");
        }

        private void CarregarComboBarbeiros()
        {
            try
            {
                cboBarbeiros.DataSource = null;
                cboBarbeiros.DataSource = _repositorio.ListarTodos();
                cboBarbeiros.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar barbeiros: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboBarbeiros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBarbeiros.SelectedItem is Barbeiro b)
            {
                _barbeiroAtual = b;
                txtNome.Text = b.Nome;
                txtCpf.Text = b.Cpf;
                txtTelefone.Text = b.Telefone;
                dtpAdmissao.Value = b.DataAdmissao;
                chkAtivo.Checked = b.Ativo;
                AtualizarListaEspecialidades();
            }
        }

        private void AtualizarListaEspecialidades()
        {
            lstEspecialidades.DataSource = null;
            lstEspecialidades.DataSource = _barbeiroAtual.Especialidades;
        }

        private void BtnAddEsp_Click(object sender, EventArgs e)
        {
            string nome = cboCategoria.Text.Trim();
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Escolha ou digite uma especialidade.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _barbeiroAtual.Especialidades.Add(new Especialidade
            {
                Nome = nome,
                BarbeiroId = _barbeiroAtual.Id
            });
            AtualizarListaEspecialidades();
            cboCategoria.Text = string.Empty;
        }

        private void BtnRemEsp_Click(object sender, EventArgs e)
        {
            if (lstEspecialidades.SelectedItem is Especialidade esp)
            {
                _barbeiroAtual.Especialidades.Remove(esp);
                if (esp.Id > 0)
                {
                    try { _repositorio.RemoverEspecialidade(esp.Id); }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao remover especialidade: " + ex.Message,
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                AtualizarListaEspecialidades();
            }
            else
            {
                MessageBox.Show("Selecione uma especialidade para remover.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O nome do barbeiro é obrigatório.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCpf.Text))
            {
                MessageBox.Show("O CPF é obrigatório.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCpf.Focus();
                return false;
            }
            return true;
        }

        private void LerCampos()
        {
            _barbeiroAtual.Nome = txtNome.Text.Trim();
            _barbeiroAtual.Cpf = txtCpf.Text.Trim();
            _barbeiroAtual.Telefone = txtTelefone.Text.Trim();
            _barbeiroAtual.DataAdmissao = dtpAdmissao.Value;
            _barbeiroAtual.Ativo = chkAtivo.Checked;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                LerCampos();
                if (_barbeiroAtual.Id == 0)
                {
                    _repositorio.Inserir(_barbeiroAtual);
                    MessageBox.Show("Barbeiro cadastrado!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _repositorio.Editar(_barbeiroAtual);
                    foreach (var esp in _barbeiroAtual.Especialidades)
                    {
                        if (esp.Id == 0)
                        {
                            esp.BarbeiroId = _barbeiroAtual.Id;
                            _repositorio.AdicionarEspecialidade(esp);
                        }
                    }
                    MessageBox.Show("Barbeiro atualizado!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                NovoBarbeiro();
                CarregarComboBarbeiros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar barbeiro: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (_barbeiroAtual.Id == 0)
            {
                MessageBox.Show("Selecione um barbeiro para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var resp = MessageBox.Show("Excluir este barbeiro e suas especialidades?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes) return;
            try
            {
                _repositorio.Deletar(_barbeiroAtual.Id);
                MessageBox.Show("Barbeiro excluído.", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                NovoBarbeiro();
                CarregarComboBarbeiros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NovoBarbeiro()
        {
            _barbeiroAtual = new Barbeiro();
            txtNome.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            dtpAdmissao.Value = DateTime.Now;
            chkAtivo.Checked = true;
            cboCategoria.Text = string.Empty;
            cboBarbeiros.SelectedIndex = -1;
            AtualizarListaEspecialidades();
        }
    }
}