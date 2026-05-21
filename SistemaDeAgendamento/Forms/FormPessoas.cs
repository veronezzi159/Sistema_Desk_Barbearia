using SistemaDeAgendamento.Models;
using SistemaDeAgendamento.Repositories;

using System;
using System.Windows.Forms;
using SistemaDeAgendamento.Models;
using SistemaDeAgendamento.Repositories;

namespace SistemaDeAgendamento
{
    public partial class FormPessoa : Form
    {
        private readonly PessoaRepository _repositorio = new PessoaRepository();
        private int _idSelecionado = 0;

        private ListBox lstPessoas;
        private TextBox txtNome;
        private TextBox txtSobrenome;
        private TextBox txtCpf;
        private TextBox txtTelefone;
        private Button btnSalvar;
        private Button btnEditar;
        private Button btnExcluir;
        private Button btnLimpar;

        public FormPessoa()
        {
            InitializeComponent();
            MontarTela();
            CarregarPessoas();
        }

        private void MontarTela()
        {
            this.Text = "Cadastro de Clientes";
            this.Width = 640;
            this.Height = 420;

            lstPessoas = new ListBox { Left = 20, Top = 20, Width = 260, Height = 320 };
            lstPessoas.SelectedIndexChanged += LstPessoas_SelectedIndexChanged;

            int x = 310;
            CriarLabel("Nome:", x, 30);
            txtNome = new TextBox { Left = x, Top = 48, Width = 280, MaxLength = 100 };

            CriarLabel("Sobrenome:", x, 80);
            txtSobrenome = new TextBox { Left = x, Top = 98, Width = 280, MaxLength = 100 };

            CriarLabel("CPF:", x, 130);
            txtCpf = new TextBox { Left = x, Top = 148, Width = 280, MaxLength = 11 };

            CriarLabel("Telefone:", x, 180);
            txtTelefone = new TextBox { Left = x, Top = 198, Width = 280, MaxLength = 20 };

            btnSalvar = new Button { Left = x, Top = 260, Width = 90, Text = "Salvar" };
            btnEditar = new Button { Left = x + 95, Top = 260, Width = 90, Text = "Editar" };
            btnExcluir = new Button { Left = x + 190, Top = 260, Width = 90, Text = "Excluir" };
            btnLimpar = new Button { Left = x, Top = 300, Width = 90, Text = "Limpar" };

            btnSalvar.Click += BtnSalvar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnExcluir.Click += BtnExcluir_Click;
            btnLimpar.Click += (s, e) => LimparCampos();

            this.Controls.Add(lstPessoas);
            this.Controls.Add(txtNome);
            this.Controls.Add(txtSobrenome);
            this.Controls.Add(txtCpf);
            this.Controls.Add(txtTelefone);
            this.Controls.Add(btnSalvar);
            this.Controls.Add(btnEditar);
            this.Controls.Add(btnExcluir);
            this.Controls.Add(btnLimpar);
        }

        private void CriarLabel(string texto, int left, int top)
        {
            var label = new Label { Left = left, Top = top, Width = 120, Text = texto };
            this.Controls.Add(label);
        }

        private void CarregarPessoas()
        {
            try
            {
                lstPessoas.DataSource = null;
                lstPessoas.DataSource = _repositorio.ListarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LstPessoas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var p = lstPessoas.SelectedItem as Pessoa;
            if (p == null) return;

            _idSelecionado = p.Id;
            txtNome.Text = p.FirstName;
            txtSobrenome.Text = p.LastName;
            txtCpf.Text = p.Cpf;
            txtTelefone.Text = p.Phone;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O nome é obrigatório.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSobrenome.Text))
            {
                MessageBox.Show("O sobrenome é obrigatório.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSobrenome.Focus();
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

        private Pessoa LerCampos()
        {
            return new Pessoa
            {
                Id = _idSelecionado,
                FirstName = txtNome.Text.Trim(),
                LastName = txtSobrenome.Text.Trim(),
                Cpf = txtCpf.Text.Trim(),
                Phone = txtTelefone.Text.Trim()
            };
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                _repositorio.Inserir(LerCampos());
                MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarPessoas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Selecione um cliente na lista para editar.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarCampos()) return;
            try
            {
                _repositorio.Editar(LerCampos());
                MessageBox.Show("Cliente atualizado!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarPessoas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao editar: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (_idSelecionado == 0)
            {
                MessageBox.Show("Selecione um cliente na lista para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var resposta = MessageBox.Show("Deseja realmente excluir este cliente?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta != DialogResult.Yes) return;
            try
            {
                _repositorio.Deletar(_idSelecionado);
                MessageBox.Show("Cliente excluído.", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
                CarregarPessoas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            _idSelecionado = 0;
            txtNome.Clear();
            txtSobrenome.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            lstPessoas.ClearSelected();
        }
    }
}
