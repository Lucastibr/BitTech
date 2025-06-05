using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace GarantiaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GarantiaController(IHttpService<Garantia> httpService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateGarantia(Garantia garantia)
    {
        return await httpService.CreateAsync(garantia);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGarantiaById(Guid id)
    {
        return await httpService.GetByIdAsync(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetGarantias()
    {
        return await httpService.GetAllAsync();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGarantia(Guid id, Garantia garantia)
    {
        return await httpService.UpdateAsync(id, garantia);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGarantia(Guid id)
    {
        return await httpService.DeleteAsync(id);
    }
}