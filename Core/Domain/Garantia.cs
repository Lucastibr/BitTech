using Core.Domain.Base;

namespace Core.Domain;

public class Garantia : Entity
{
    public string? Nome { get; set; }

    public decimal Valor { get; set; }

    public int? PrazoAnos { get; set; }
}