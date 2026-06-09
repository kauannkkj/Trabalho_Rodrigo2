namespace Vendinha.Dominio;

public class Cliente
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; } = string.Empty;

    public List<Divida> Dividas { get; set; } = [];

    public int Idade
    {
        get
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;
            if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade;
        }
    }
}