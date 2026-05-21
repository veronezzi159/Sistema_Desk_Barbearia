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
    public partial class FormService : Form
    {
        public partial class FormService : Form
        {
            private ServiceDto _selected = null;

            public FormService()
            {
                InitializeComponent();
            }

            // ── Load ──────────────────────────────────────────────────────────────

            private void FormService_Load(object sender, EventArgs e)
            {
                LoadGrid();
            }

            // ── Grid ──────────────────────────────────────────────────────────────

            private void LoadGrid()
            {
                try
                {
                    var services = ServiceRepository.GetAll();
                    dgvServices.DataSource = null;
                    dgvServices.DataSource = new System.ComponentModel.BindingList<ServiceDto>(
                        new System.Collections.Generic.List<ServiceDto>(services));
                }
                catch (Exception ex)
                {
                    ShowError("Erro ao carregar serviços", ex);
                }
            }

            private void dgvServices_SelectionChanged(object sender, EventArgs e)
            {
                if (dgvServices.CurrentRow == null) return;

                _selected = dgvServices.CurrentRow.DataBoundItem as ServiceDto;
                if (_selected == null) return;

                txtName.Text        = _selected.Name;
                txtDescription.Text = _selected.Description;
                txtPrice.Text       = _selected.Price.ToString("F2");
                chkActive.Checked   = _selected.Active;
            }

            // ── Buttons ───────────────────────────────────────────────────────────

            private void btnNew_Click(object sender, EventArgs e)
            {
                _selected = null;
                ClearFields();
                txtName.Focus();
            }

            private void btnSave_Click(object sender, EventArgs e)
            {
                if (!IsFormValid()) return;

                try
                {
                    decimal price;
                    if (!decimal.TryParse(txtPrice.Text.Replace(",", "."),
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out price))
                    {
                        Warn("Valor inválido. Use o formato: 35.90");
                        return;
                    }

                    var dto = new ServiceDto
                    {
                        Id          = _selected != null ? _selected.Id : 0,
                        Name        = txtName.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        Price       = price,
                        Active      = chkActive.Checked
                    };

                    if (_selected == null)
                        ServiceRepository.Insert(dto);
                    else
                        ServiceRepository.Update(dto);

                    LoadGrid();
                    ClearFields();
                    _selected = null;

                    MessageBox.Show("Serviço salvo com sucesso!",
                                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ShowError("Erro ao salvar serviço", ex);
                }
            }

            private void btnDelete_Click(object sender, EventArgs e)
            {
                if (_selected == null)
                {
                    Warn("Selecione um serviço na lista para excluir.");
                    return;
                }

                var confirm = MessageBox.Show(
                    $"Deseja excluir o serviço \"{_selected.Name}\"?\n\nEsta ação não pode ser desfeita.",
                    "Confirmar exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                try
                {
                    ServiceRepository.Delete(_selected.Id);
                    LoadGrid();
                    ClearFields();
                    _selected = null;
                }
                catch (Exception ex)
                {
                    ShowError("Erro ao excluir serviço", ex);
                }
            }

            private void btnClose_Click(object sender, EventArgs e) => Close();

            // ── Helpers ───────────────────────────────────────────────────────────

            private bool IsFormValid()
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                    return Warn("Informe o nome do serviço.");

                if (string.IsNullOrWhiteSpace(txtPrice.Text))
                    return Warn("Informe o valor do serviço.");

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

            private void ClearFields()
            {
                txtName.Clear();
                txtDescription.Clear();
                txtPrice.Clear();
                chkActive.Checked = true;
            }
        }
    }
}
