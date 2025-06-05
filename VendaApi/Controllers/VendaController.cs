using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace VendaApi.Controllers;

public class VendaController(IHttpService<Venda> httpService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateVenda(Venda venda)
    {
        return await httpService.CreateAsync(venda);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVendaById(Guid id)
    {
        return await httpService.GetByIdAsync(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetVendas()
    {
        return await httpService.GetAllAsync();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVenda(Guid id)
    {
        return await httpService.DeleteAsync(id);
    }
}