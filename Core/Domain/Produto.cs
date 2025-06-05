using Core.Domain.Base;

namespace Core.Domain;

public class Produto : Entity
{
    public string? Nome { get; set; }

    public decimal Valor { get; set; }

    public int? EstoqueMinimo { get; set; }

    public int? EstoqueMaximo { get; set; }

    public int? SaldoEstoque { get; set; }

    public string? Fornecedor { get; set; }

    public bool PossuiGarantia { get; set; }
}