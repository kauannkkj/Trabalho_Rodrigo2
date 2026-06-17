using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vendinha.Dominio
{
    public class Cliente : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$",
            ErrorMessage = "O nome não pode conter números ou caracteres especiais.")]
        public string NomeCompleto { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$",
            ErrorMessage = "O CPF deve conter exatamente 11 números (sem pontos ou traços).")]
        public string Cpf { get; set; } = string.Empty;

        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido. Use o formato exemplo@dominio.com.")]
        [StringLength(150, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres.")]
        public string Email { get; set; } = string.Empty;

        public List<Divida> Dividas { get; set; } = new();

        public int Idade
        {
            get
            {
                var hoje = DateTime.Today;
                var totalAnos = hoje.Year - DataNascimento.Year;
                var diaAnoNascimento = hoje.AddYears(-totalAnos);
                if (DataNascimento > diaAnoNascimento) totalAnos--;
                return totalAnos;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DataNascimento.Date >= DateTime.Today)
                yield return new ValidationResult(
                    "A data de nascimento não pode ser hoje ou no futuro.",
                    new[] { nameof(DataNascimento) });

            if (DataNascimento.Year < 1900)
                yield return new ValidationResult(
                    "Data de nascimento inválida.",
                    new[] { nameof(DataNascimento) });
        }
    }
}
