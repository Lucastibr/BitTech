using Core.Domain.Base;

namespace Core.Domain;

public class ItemVenda : Entity
{
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal ValorTotal => Quantidade * ValorUnitario;
}