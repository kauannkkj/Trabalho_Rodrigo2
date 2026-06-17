using System;
using System.ComponentModel.DataAnnotations;

namespace Vendinha.Dominio
{
    public class Divida
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório.")]
        public int ClienteId { get; set; }

        [Range(0.01, 9999.99,
            ErrorMessage = "O valor deve ser entre R$ 0,01 e R$ 9.999,99.")]
        public decimal Valor { get; set; }

        public bool Paga { get; set; } = false;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataPagamento { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
