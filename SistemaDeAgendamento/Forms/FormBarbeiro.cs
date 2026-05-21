using System;
using System.Windows.Forms;
using SistemaDeAgendamento.Models;
using SistemaDeAgendamento.Repositories;

namespace SistemaDeAgendamento.Forms
{
    public partial class FormBarbeiro : Form
    {
        private readonly BarbeiroRepository _repositorio = new BarbeiroRepository();
        private BarbeiroDto _atual = null;

        public FormBarbeiro()
        {
            InitializeComponent();
        }

        // ── Load ──────────────────────────────────────────────────────────────

        private void FormBarbeiro_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        // ── Grid ──────────────────────────────────────────────────────────────

        private void CarregarGrid()
        {
            try
            {
                dgvBarbeiros.DataSource = null;
                dgvBarbeiros.DataSource = new System.ComponentModel.BindingList<BarbeiroDto>(
                _repositorio.ListarTodos());
            }
            catch (Exception ex)
            {
                ShowError("Erro ao carregar barbeiros", ex);
            }
        }

        private void dgvBarbeiros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBarbeiros.CurrentRow == null) return;

            _atual = dgvBarbeiros.CurrentRow.DataBoundItem as BarbeiroDto;
            if (_atual == null) return;

            txtNome.Text = _atual.FirstName;
            txtSobrenome.Text = _atual.LastName;
            txtCpf.Text = _atual.Cpf;
            txtTelefone.Text = _atual.Phone;
        }

        // ── Buttons ───────────────────────────────────────────────────────────

        private void btnNovo_Click(object sender, EventArgs e)
        {
            _atual = null;
            LimparCampos();
            txtNome.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var dto = new BarbeiroDto
                {
                    Id = _atual != null ? _atual.Id : 0,
                    FirstName = txtNome.Text.Trim(),
                    LastName = txtSobrenome.Text.Trim(),
                    Cpf = txtCpf.Text.Trim(),
                    Phone = txtTelefone.Text.Trim()
                };

                if (_atual == null)
                    _repositorio.Inserir(dto);
                else
                    _repositorio.Editar(dto);

                CarregarGrid();
                LimparCampos();
                _atual = null;

                MessageBox.Show("Barbeiro salvo com sucesso!",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ShowError("Erro ao salvar barbeiro", ex);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_atual == null)
            {
                Warn("Selecione um barbeiro na lista para excluir.");
                return;
            }

            var confirm = MessageBox.Show(
                $"Deseja excluir o barbeiro \"{_atual.FullName}\"?\n\nEsta ação não pode ser desfeita.",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                _repositorio.Deletar(_atual.Id);
                CarregarGrid();
                LimparCampos();
                _atual = null;
            }
            catch (Exception ex)
            {
                ShowError("Erro ao excluir barbeiro", ex);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e) => Close();

        // ── Helpers ───────────────────────────────────────────────────────────

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
                return Warn("Informe o nome do barbeiro.");

            if (string.IsNullOrWhiteSpace(txtSobrenome.Text))
                return Warn("Informe o sobrenome do barbeiro.");

            if (string.IsNullOrWhiteSpace(txtCpf.Text))
                return Warn("Informe o CPF do barbeiro.");

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

        private void LimparCampos()
        {
            txtNome.Clear();
            txtSobrenome.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
        }
    }
}