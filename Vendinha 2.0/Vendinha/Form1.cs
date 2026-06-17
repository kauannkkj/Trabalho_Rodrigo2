using System;
using System.Linq;
using System.Windows.Forms;
using Vendinha.Services;

namespace Vendinha
{
    public partial class Form1 : Form
    {
        private readonly ClienteService _clienteService = new();

        private int _paginaAtual = 1;
        private const int TamanhoPagina = 10;
        private int _totalRegistros = 0;

        public Form1()
        {
            InitializeComponent();

            txtBusca.TextChanged   += (s, e) => { _paginaAtual = 1; CarregarClientes(); };
            btnNovoCliente.Click   += BtnNovoCliente_Click;
            btnExcluir.Click       += BtnExcluir_Click;
            btnAnterior.Click      += (s, e) => { if (_paginaAtual > 1) { _paginaAtual--; CarregarClientes(); } };
            btnProxima.Click       += (s, e) => { if (_paginaAtual < TotalPaginas()) { _paginaAtual++; CarregarClientes(); } };
            dgvClientes.CellDoubleClick += DgvClientes_CellDoubleClick;

            CarregarClientes();
        }

        private int TotalPaginas() =>
            (int)Math.Ceiling(_totalRegistros / (double)TamanhoPagina);

        private void CarregarClientes()
        {
            var lista = _clienteService.ListarPaginado(
                txtBusca.Text, _paginaAtual, TamanhoPagina, out _totalRegistros);

            dgvClientes.DataSource = lista;

            if (dgvClientes.Columns["Id"] != null)
                dgvClientes.Columns["Id"].Visible = false;

            int totalPag = Math.Max(TotalPaginas(), 1);
            lblPagina.Text      = $"Página {_paginaAtual} de {totalPag}  ({_totalRegistros} clientes)";
            btnAnterior.Enabled = _paginaAtual > 1;
            btnProxima.Enabled  = _paginaAtual < totalPag;
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

            int    id   = (int)dgvClientes.Rows[e.RowIndex].Cells["Id"].Value;
            string nome = dgvClientes.Rows[e.RowIndex].Cells["Nome"].Value?.ToString() ?? "";

            using var form = new FormGerenciarDividas(id, nome);
            form.ShowDialog();
            CarregarClientes();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            int id = (int)dgvClientes.CurrentRow.Cells["Id"].Value;

            var confirmacao = MessageBox.Show(
                "Deseja excluir este cliente e todas as suas dívidas?",
                "Confirmar exclusão",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacao != DialogResult.Yes) return;

            var sucesso = _clienteService.Excluir(id, out var erros);
            if (!sucesso)
            {
                MessageBox.Show(erros.First().ErrorMessage);
                return;
            }

            MessageBox.Show("Cliente excluído com sucesso!");
            if (_paginaAtual > 1 && (_totalRegistros - 1) <= (_paginaAtual - 1) * TamanhoPagina)
                _paginaAtual--;
            CarregarClientes();
        }
    }
}
