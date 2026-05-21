using SistemaDeAgendamento.Models;
using SistemaDeAgendamento.Repositories;

uusing System;
using System.Windows.Forms;
using SistemaDeAgendamento.Models;
using SistemaDeAgendamento.Repositories;

namespace SistemaDeAgendamento
{
    public partial class FormPessoa : Form
    {
        private readonly PessoaRepository _repositorio = new PessoaRepository();
        private int _idSelecionado = 0;

        // Controles da tela
        private ListBox lstPessoas;
        private TextBox txtNome;
        private TextBox txtCpf;
        private TextBox txtTelefone;
        private TextBox txtEmail;
        private DateTimePicker dtpNascimento;
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

        // Cria e posiciona todos os controles na tela.
        private void MontarTela()
        {
            this.Text = "Cadastro de Pessoas";
            this.Width = 640;
            this.Height = 460;

            lstPessoas = new ListBox { Left = 20, Top = 20, Width = 260, Height = 360 };
            lstPessoas.SelectedIndexChanged += LstPessoas_SelectedIndexChanged;

            int x = 310;
            CriarLabel("Nome:", x, 30);
            txtNome = new TextBox { Left = x, Top = 48, Width = 280 };

            CriarLabel("CPF:", x, 80);
            txtCpf = new TextBox { Left = x, Top = 98, Width = 280 };

            CriarLabel("Telefone:", x, 130);
            txtTelefone = new TextBox { Left = x, Top = 148, Width = 280 };

            CriarLabel("E-mail:", x, 180);
            txtEmail = new TextBox { Left = x, Top = 198, Width = 280 };

            CriarLabel("Nascimento:", x, 230);
            dtpNascimento = new DateTimePicker { Left = x, Top = 248, Width = 280, Format = DateTimePickerFormat.Short };

            btnSalvar = new Button { Left = x, Top = 300, Width = 90, Text = "Salvar" };
            btnEditar = new Button { Left = x + 95, Top = 300, Width = 90, Text = "Editar" };
            btnExcluir = new Button { Left = x + 190, Top = 300, Width = 90, Text = "Excluir" };
            btnLimpar = new Button { Left = x, Top = 340, Width = 90, Text = "Limpar" };

            btnSalvar.Click += BtnSalvar_Click;
            btnEditar.Click += BtnEditar_Click;
            btnExcluir.Click += BtnExcluir_Click;
            btnLimpar.Click += (s, e) => LimparCampos();

            this.Controls.Add(lstPessoas);
            this.Controls.Add(txtNome);
            this.Controls.Add(txtCpf);
            this.Controls.Add(txtTelefone);
            this.Controls.Add(txtEmail);
            this.Controls.Add(dtpNascimento);
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

        // Lê todas as pessoas do banco e mostra no ListBox.
        private void CarregarPessoas()
        {
            try
            {
                lstPessoas.DataSource = null;
                lstPessoas.DataSource = _repositorio.ListarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar pessoas: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Ao clicar numa pessoa da lista, preenche os campos.
        private void LstPessoas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPessoas.SelectedItem is Pessoa p)
            {
                _idSelecionado = p.Id;
                txtNome.Text = p.Nome;
                txtCpf.Text = p.Cpf;
                txtTelefone.Text = p.Telefone;
                txtEmail.Text = p.Email;
                dtpNascimento.Value = p.DataNascimento;
            }
        }

        // Validação dos campos obrigatórios.
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O nome é obrigatório.", "Atenção",
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

        private Pessoa LerCampos()
        {
            return new Pessoa
            {
                Id = _idSelecionado,
                Nome = txtNome.Text.Trim(),
                Cpf = txtCpf.Text.Trim(),
                Telefone = txtTelefone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                DataNascimento = dtpNascimento.Value
            };
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;
            try
            {
                _repositorio.Inserir(LerCampos());
                MessageBox.Show("Pessoa cadastrada com sucesso!", "Sucesso",
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
                MessageBox.Show("Selecione uma pessoa na lista para editar.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidarCampos()) return;
            try
            {
                _repositorio.Editar(LerCampos());
                MessageBox.Show("Dados atualizados!", "Sucesso",
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
                MessageBox.Show("Selecione uma pessoa na lista para excluir.", "Atenção",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var resposta = MessageBox.Show("Deseja realmente excluir esta pessoa?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resposta != DialogResult.Yes) return;
            try
            {
                _repositorio.Deletar(_idSelecionado);
                MessageBox.Show("Pessoa excluída.", "Sucesso",
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
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            dtpNascimento.Value = DateTime.Now;
            lstPessoas.ClearSelected();
        }
    }
}
