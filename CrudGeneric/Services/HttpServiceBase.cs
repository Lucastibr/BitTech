using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Service.Services;

public class HttpServiceBase<T>(IRepository<T> repository) : IHttpService<T> where T : class
{
    public async Task<IActionResult> CreateAsync(T entity)
    {
        try
        {
            var createdEntity = await repository.CreateAsync(entity);
            var id = createdEntity.GetType().GetProperty("Id")?.GetValue(createdEntity, null);
            return new CreatedAtActionResult("GetById", "Items", new { id }, createdEntity);
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var entity = await repository.GetByIdAsync(id);

        if (entity == null)
            return new NotFoundObjectResult("Item não encontrado.");
        
        return new OkObjectResult(entity);
    }

    public async Task<IActionResult> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return new OkObjectResult(entities);
    }

    public async Task<IActionResult> UpdateAsync(Guid id, T entity)
    {
        var updatedEntity = await repository.UpdateAsync(entity);

        return new OkObjectResult(updatedEntity);
    }

    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var success = await repository.DeleteAsync(id);

        if (!success)
            return new NotFoundObjectResult("Item não encontrado.");
        
        return new NoContentResult();
    }
}