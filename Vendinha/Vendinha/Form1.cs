using Microsoft.EntityFrameworkCore;
using System.Data;
using Vendinha.Dados;
using Vendinha.Dominio;


namespace Vendinha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            txtBusca.TextChanged += (s, e) => CarregarClientes();
            btnNovoCliente.Click += BtnNovoCliente_Click;
            dgvClientes.CellDoubleClick += DgvClientes_CellDoubleClick;
            btnExcluir.Click += BtnExcluir_Click;

            CarregarClientes();
        }

        private void CarregarClientes()
        {
            using var db = new VendinhaContext();

            var query = db.Clientes.Include(c => c.Dividas).AsQueryable();

            if (!string.IsNullOrWhiteSpace(txtBusca.Text))
            {
                query = query.Where(c => c.NomeCompleto
                    .ToLower()
                    .Contains(txtBusca.Text.ToLower()));
            }

            var lista = query.ToList()
                .Select(c => new
                {
                    c.Id,
                    Nome = c.NomeCompleto,
                    c.Cpf,
                    c.Idade,
                    c.Email,
                    TotalDevido = c.Dividas
                        .Where(d => !d.Paga)
                        .Sum(d => d.Valor)
                })
                .OrderByDescending(c => c.TotalDevido)
                .ToList();

            dgvClientes.DataSource = lista;

            if (dgvClientes.Columns["Id"] != null)
                dgvClientes.Columns["Id"].Visible = false;
        }

        private void BtnNovoCliente_Click(object sender, EventArgs e)
        {
            using var form = new FormCadastroCliente();

            if (form.ShowDialog() == DialogResult.OK)
                CarregarClientes();
        }

        private void DgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = (int)dgvClientes.Rows[e.RowIndex].Cells["Id"].Value;
            string nome = dgvClientes.Rows[e.RowIndex].Cells["Nome"].Value?.ToString() ?? "";

            using var form = new FormGerenciarDividas(id, nome);
            form.ShowDialog();

            CarregarClientes();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            int id = (int)dgvClientes.CurrentRow.Cells["Id"].Value;

            using var db = new VendinhaContext();

            var cliente = db.Clientes.Find(id);
            if (cliente == null) return;

            db.Clientes.Remove(cliente);
            db.SaveChanges();

            MessageBox.Show("Excluído!");

            CarregarClientes();
        }
    }
}