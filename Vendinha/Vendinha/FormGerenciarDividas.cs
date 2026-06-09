using System;
using System.Linq;
using System.Windows.Forms;
using Vendinha.Dados;
using Vendinha.Dominio;

namespace Vendinha
{
    public partial class FormGerenciarDividas : Form
    {
        private int _clienteId;

        public FormGerenciarDividas(int clienteId, string nomeCliente)
        {
            InitializeComponent();

            _clienteId = clienteId;
            lblCliente.Text = "Cliente: " + nomeCliente;

            btnPendurar.Click += BtnPendurar_Click;
            btnPagar.Click += BtnPagar_Click;

            CarregarDividas();
        }

        private void CarregarDividas()
        {
            using var db = new VendinhaContext();

            var lista = db.Dividas
                .Where(d => d.ClienteId == _clienteId)
                .Select(d => new
                {
                    d.Id,
                    d.Valor,
                    Paga = d.Paga ? "SIM" : "NÃO"
                })
                .ToList();

            dgvDividas.DataSource = lista;

            if (dgvDividas.Columns["Id"] != null)
                dgvDividas.Columns["Id"].Visible = false;
        }

        private void BtnPendurar_Click(object sender, EventArgs e)
        {
            using var db = new VendinhaContext();

            bool temDivida = db.Dividas
                .Any(d => d.ClienteId == _clienteId && !d.Paga);

            if (temDivida)
            {
                MessageBox.Show("Cliente já possui dívida em aberto!");
                return;
            }

            var divida = new Divida
            {
                ClienteId = _clienteId,
                Valor = numValor.Value,
                Paga = false,
                DataCriacao = DateTime.Now
            };

            db.Dividas.Add(divida);
            db.SaveChanges();

            MessageBox.Show("Dívida adicionada!");

            CarregarDividas();
        }
        private void BtnPagar_Click(object sender, EventArgs e)
        {
            if (dgvDividas.CurrentRow == null) return;

            int id = (int)dgvDividas.CurrentRow.Cells["Id"].Value;

            using var db = new VendinhaContext();

            var divida = db.Dividas.Find(id);

            if (divida != null)
            {
                divida.Paga = true;
                db.SaveChanges();

                MessageBox.Show("Dívida paga!");
                CarregarDividas();
            }
        }
    }
}