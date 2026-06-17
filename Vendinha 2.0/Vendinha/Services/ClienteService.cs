using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Vendinha.Dados;
using Vendinha.Dominio;

namespace Vendinha.Services
{
    public class ClienteService
    {
        public bool Validar(Cliente cliente, out List<ValidationResult> listaErros)
        {
            listaErros = new List<ValidationResult>();

            return Validator.TryValidateObject(
                cliente,
                new ValidationContext(cliente),
                listaErros,
                true);
        }

        public bool Cadastrar(Cliente cliente, out List<ValidationResult> listaErros)
        {
            cliente.Cpf = Regex.Replace(cliente.Cpf ?? "", @"[^\d]", "");

            if (!Validar(cliente, out listaErros))
                return false;

            using var db = new VendinhaContext();
            if (db.Clientes.Any(c => c.Cpf == cliente.Cpf))
            {
                listaErros.Add(new ValidationResult(
                    "CPF já cadastrado.",
                    new[] { nameof(Cliente.Cpf) }));
                return false;
            }

            db.Clientes.Add(cliente);
            db.SaveChanges();
            return true;
        }

        public bool Atualizar(Cliente cliente, out List<ValidationResult> listaErros)
        {
            if (!Validar(cliente, out listaErros))
                return false;

            using var db = new VendinhaContext();
            var existente = db.Clientes.Find(cliente.Id);
            if (existente == null)
            {
                listaErros.Add(new ValidationResult("Cliente não encontrado."));
                return false;
            }

            existente.NomeCompleto   = cliente.NomeCompleto;
            existente.Email          = cliente.Email;
            existente.DataNascimento = cliente.DataNascimento;
            db.SaveChanges();
            return true;
        }

        public bool Excluir(int id, out List<ValidationResult> listaErros)
        {
            listaErros = new List<ValidationResult>();
            using var db = new VendinhaContext();
            var c = db.Clientes.Find(id);
            if (c == null)
            {
                listaErros.Add(new ValidationResult("Cliente não encontrado."));
                return false;
            }
            db.Clientes.Remove(c);
            db.SaveChanges();
            return true;
        }


        public Cliente? BuscarPorId(int id)
        {
            using var db = new VendinhaContext();
            return db.Clientes.Find(id);
        }


        public List<object> ListarPaginado(string filtroNome, int pagina, int tamanhoPagina, out int totalRegistros)
        {
            using var db = new VendinhaContext();

            var query = db.Clientes.Include(c => c.Dividas).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtroNome))
                query = query.Where(c => c.NomeCompleto.ToLower().Contains(filtroNome.ToLower()));

            totalRegistros = query.Count();

            return query
                .OrderBy(c => c.NomeCompleto)
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToList()
                .Select(c => (object)new
                {
                    c.Id,
                    Nome = c.NomeCompleto,
                    c.Cpf,
                    c.Idade,
                    c.Email,
                    TotalDevido = c.Dividas.Where(d => !d.Paga).Sum(d => d.Valor)
                })
                .ToList();
        }
    }
}
