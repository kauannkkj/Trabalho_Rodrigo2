using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Vendinha.Dados;
using Vendinha.Dominio;

namespace Vendinha.Services
{
    public class DividaService
    {
        public bool Validar(Divida divida, out List<ValidationResult> listaErros)
        {
            var contexto = new ValidationContext(divida);
            var erros = new List<ValidationResult>();
            listaErros = erros;

            var valido = Validator.TryValidateObject(
                divida, contexto, erros, validateAllProperties: true);

            using var db = new VendinhaContext();
            bool temAberta = db.Dividas.Any(d => d.ClienteId == divida.ClienteId && !d.Paga);
            if (temAberta)
            {
                erros.Add(new ValidationResult(
                    "O cliente já possui uma dívida em aberto.",
                    new[] { nameof(Divida.ClienteId) }));
                valido = false;
            }

            return valido;
        }

        public bool Pendurar(Divida divida, out List<ValidationResult> listaErros)
        {
            if (!Validar(divida, out listaErros))
                return false;

            using var db = new VendinhaContext();
            db.Dividas.Add(divida);
            db.SaveChanges();
            return true;
        }

        public bool Pagar(int dividaId, out List<ValidationResult> listaErros)
        {
            listaErros = new List<ValidationResult>();
            using var db = new VendinhaContext();
            var divida = db.Dividas.Find(dividaId);

            if (divida == null)
            {
                listaErros.Add(new ValidationResult("Dívida não encontrada."));
                return false;
            }

            if (divida.Paga)
            {
                listaErros.Add(new ValidationResult("Esta dívida já foi paga e não pode ser alterada."));
                return false;
            }

            divida.Paga = true;
            divida.DataPagamento = DateTime.Now;
            db.SaveChanges();
            return true;
        }

        public bool Excluir(int dividaId, out List<ValidationResult> listaErros)
        {
            listaErros = new List<ValidationResult>();
            using var db = new VendinhaContext();
            var divida = db.Dividas.Find(dividaId);
            if (divida == null)
            {
                listaErros.Add(new ValidationResult("Dívida não encontrada."));
                return false;
            }
            db.Dividas.Remove(divida);
            db.SaveChanges();
            return true;
        }

        public List<object> ListarPorCliente(int clienteId)
        {
            using var db = new VendinhaContext();
            return db.Dividas
                .Where(d => d.ClienteId == clienteId)
                .OrderByDescending(d => d.DataCriacao)
                .ToList()
                .Select(d => (object)new
                {
                    d.Id,
                    d.Valor,
                    Paga = d.Paga ? "SIM" : "NÃO",
                    DataCriacao = d.DataCriacao.ToString("dd/MM/yyyy"),
                    DataPagamento = d.DataPagamento.HasValue
                        ? d.DataPagamento.Value.ToString("dd/MM/yyyy")
                        : "-"
                })
                .ToList();
        }
    }
}
