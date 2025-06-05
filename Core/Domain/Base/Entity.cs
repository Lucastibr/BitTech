namespace Core.Domain.Base;

/// <summary>
/// Classe base para entidades do domínio
/// </summary>
public abstract class Entity
{
    public Guid? Id { get; set; }
}
