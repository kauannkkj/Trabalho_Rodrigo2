using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Forms;
using Vendinha.Dominio;
using Vendinha.Services;

namespace Vendinha
{
    public partial class FormCadastroCliente : Form
    {
        private readonly ClienteService _clienteService = new();
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
            var c = _clienteService.BuscarPorId(_clienteIdEdicao!.Value);
            if (c == null) return;

            txtNome.Text            = c.NomeCompleto;
            txtCpf.Text             = c.Cpf;
            txtCpf.ReadOnly         = true;
            dtpDataNascimento.Value = c.DataNascimento;
            txtEmail.Text           = c.Email;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente
            {
                Id              = _clienteIdEdicao ?? 0,
                NomeCompleto    = txtNome.Text,
                Cpf             = txtCpf.Text,
                Email           = txtEmail.Text,
                DataNascimento  = dtpDataNascimento.Value
            };

            bool sucesso;
            List<ValidationResult> erros;

            if (_clienteIdEdicao == null)
                sucesso = _clienteService.Cadastrar(cliente, out erros);
            else
                sucesso = _clienteService.Atualizar(cliente, out erros);

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

            MessageBox.Show(_clienteIdEdicao == null
                ? "Cliente cadastrado com sucesso!"
                : "Cliente atualizado com sucesso!");

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
