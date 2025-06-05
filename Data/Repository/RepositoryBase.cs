using Core.Repository;

namespace Data.Repository;

/// <summary>
/// Classe base para implementação de repositórios genéricos.
/// </summary>
/// <typeparam name="T"></typeparam>
public class RepositoryBase<T> : IRepository<T> where T : class
{
    private readonly Dictionary<Guid, T> _store = new();
    private int _nextId = 1;

    public Task<T> CreateAsync(T entity)
    {
        var idProperty = entity.GetType().GetProperty("Id");

        if (idProperty == null)
            throw new InvalidOperationException("A entidade deve ter ao menos um ID.");
        

        idProperty.SetValue(entity, _nextId++);
        _store[(Guid)idProperty.GetValue(entity)] = entity;
        return Task.FromResult(entity);
    }

    public Task<T?> GetByIdAsync(Guid id)
    {
        _store.TryGetValue(id, out var entity);
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<T>>(_store.Values);
    }

    public Task<T> UpdateAsync(T entity)
    {
        var idProperty = entity.GetType().GetProperty("Id");

        if (idProperty == null)
            throw new InvalidOperationException("A entidade deve ter ao menos um ID.");
        
        var id = (Guid)idProperty.GetValue(entity);

        if (!_store.ContainsKey(id)) return Task.FromResult<T>(null);
        _store[id] = entity;
        return Task.FromResult(entity);

    }

    public Task<bool> DeleteAsync(Guid id)
    {
        return Task.FromResult(_store.Remove(id));
    }
}