using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Vendinha.Dominio;
using Vendinha.Services;

namespace Vendinha
{
    public partial class FormGerenciarDividas : Form
    {
        private readonly DividaService _dividaService = new();
        private readonly int _clienteId;

        public FormGerenciarDividas(int clienteId, string nomeCliente)
        {
            InitializeComponent();

            _clienteId = clienteId;
            lblCliente.Text = "Cliente: " + nomeCliente;

            btnPendurar.Click      += BtnPendurar_Click;
            btnPagar.Click         += BtnPagar_Click;
            btnExcluirDivida.Click += BtnExcluirDivida_Click;

            CarregarDividas();
        }

        private void CarregarDividas()
        {
            var lista = _dividaService.ListarPorCliente(_clienteId);
            dgvDividas.DataSource = lista;

        }

        private void BtnPendurar_Click(object sender, EventArgs e)
        {
            var divida = new Divida
            {
                ClienteId   = _clienteId,
                Valor       = numValor.Value,
                Paga        = false,
                DataCriacao = DateTime.Now
            };

            var sucesso = _dividaService.Pendurar(divida, out var erros);
            if (!sucesso)
            {
                var texto = string.Join("\n", erros.Select(err =>
                {
                    var prop = err.MemberNames.FirstOrDefault() ?? "Erro";
                    return $"{prop}: {err.ErrorMessage}";
                }));
                MessageBox.Show(texto, "Dados inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Dívida registrada com sucesso!");
            CarregarDividas();
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            if (dgvDividas.CurrentRow == null) return;

            int id = (int)dgvDividas.CurrentRow.Cells["Id"].Value;

            var sucesso = _dividaService.Pagar(id, out var erros);
            if (!sucesso)
            {
                MessageBox.Show(erros.First().ErrorMessage);
                return;
            }

            MessageBox.Show("Dívida marcada como paga!");
            CarregarDividas();
        }

        private void BtnExcluirDivida_Click(object sender, EventArgs e)
        {
            if (dgvDividas.CurrentRow == null) return;

            int id = (int)dgvDividas.CurrentRow.Cells["Id"].Value;

            var confirmacao = MessageBox.Show(
                "Excluir esta dívida?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacao != DialogResult.Yes) return;

            var sucesso = _dividaService.Excluir(id, out var erros);
            if (!sucesso)
            {
                MessageBox.Show(erros.First().ErrorMessage);
                return;
            }

            MessageBox.Show("Dívida excluída!");
            CarregarDividas();
        }
    }
}
