using Microsoft.AspNetCore.Mvc;

namespace HttpBase.Interfaces;

public interface IHttpService<in T> where T : class
{
    Task<IActionResult> CreateAsync(T entity);
    Task<IActionResult> GetByIdAsync(Guid id);
    Task<IActionResult> GetAllAsync();
    Task<IActionResult> UpdateAsync(Guid id, T entity);
    Task<IActionResult> DeleteAsync(Guid id);
}
