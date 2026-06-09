using System;
using System.Linq;
using System.Windows.Forms;
using Vendinha.Dados;
using Vendinha.Dominio;
namespace Vendinha
{
    public partial class FormCadastroCliente : Form
    {
        private int? _clienteIdEdicao;

        public FormCadastroCliente()
        {
            InitializeComponent();
            btnSalvar.Click += BtnSalvar_Click;
        }

        public FormCadastroCliente(int id) : this()
        {
            _clienteIdEdicao = id;
            Carregar();
        }

        private void Carregar()
        {
            using var db = new VendinhaContext();
            var c = db.Clientes.Find(_clienteIdEdicao);

            if (c == null) return;

            txtNome.Text = c.NomeCompleto;
            txtCpf.Text = c.Cpf;
            txtCpf.ReadOnly = true;
            dtpDataNascimento.Value = c.DataNascimento;
            txtEmail.Text = c.Email;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            var nome = txtNome.Text;
            var cpf = txtCpf.Text.Replace(".", "").Replace("-", "");
            var email = txtEmail.Text;

            if (nome == "" || cpf == "" || email == "")
            {
                MessageBox.Show("Preencha tudo!");
                return;
            }

            using var db = new VendinhaContext();

            if (_clienteIdEdicao == null)
            {
                if (db.Clientes.Any(c => c.Cpf == cpf))
                {
                    MessageBox.Show("CPF já existe!");
                    return;
                }

                db.Clientes.Add(new Cliente
                {
                    NomeCompleto = nome,
                    Cpf = cpf,
                    DataNascimento = dtpDataNascimento.Value,
                    Email = email
                });

                MessageBox.Show("Cadastrado!");
            }
            else
            {
                var c = db.Clientes.Find(_clienteIdEdicao);
                if (c == null) return;

                c.NomeCompleto = nome;
                c.Email = email;
                c.DataNascimento = dtpDataNascimento.Value;

                db.Clientes.Update(c);

                MessageBox.Show("Atualizado!");
            }

            db.SaveChanges();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}