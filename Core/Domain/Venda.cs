using Core.Domain.Base;

namespace Core.Domain;

public class Venda : Entity
{
    public List<ItemVenda> Itens { get; set; } = [];
    public Garantia Garantia { get; set; }
    public decimal ValorTotal { get; set; }
}