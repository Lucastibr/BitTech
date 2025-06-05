namespace Service.Interfaces;

public interface IService<T> where T : class
{
    Task<T> CreateAsync(T entity);          
    Task<T?> GetByIdAsync(Guid? id);  
    Task<IEnumerable<T>> GetAllAsync();  
    Task<T> UpdateAsync(Guid? id, T entity); 
    Task<bool> DeleteAsync(Guid? id); 
}
