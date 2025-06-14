﻿using Core.Repository;
using Service.Interfaces;

namespace Service.Services;

public class ServiceBase<T>(IRepository<T> repository) : IService<T> where T : class
{
    public async Task<T> CreateAsync(T entity)
    {
        try
        {
            return await repository.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao criar o recurso: {ex.Message}");
        }
    }

    public async Task<T?> GetByIdAsync(Guid? id)
    {
        var entity = await repository.GetByIdAsync(id);

        return entity ?? null;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<T> UpdateAsync(Guid? id, T entity)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));
        
        var domain = await repository.GetByIdAsync(id);

        if (domain == null)
            throw new Exception("Recurso não encontrado.");

        foreach (var property in typeof(T).GetProperties())
        {
            if (property.Name == "Id") continue;
            var newValue = property.GetValue(entity);
            property.SetValue(domain, newValue);
        }

        var updatedEntity = await repository.UpdateAsync(domain);
        return updatedEntity;
    }
    
    public async Task<bool> DeleteAsync(Guid? id)
    {
        var success = await repository.DeleteAsync(id);
        return success; 
    }
}