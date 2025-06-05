using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace VendaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendaController(IService<Venda> httpService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateVenda(Venda venda)
    {
        try
        {
            await httpService.CreateAsync(venda);

            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVendaById(Guid id)
    {
        var venda = await httpService.GetByIdAsync(id);

        if (venda == null)
            return NotFound();

        return Ok(venda);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllVendas()
    {
        var vendas = await httpService.GetAllAsync();
        return Ok(vendas);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVenda(Guid id, Venda venda)
    {
        var updatedVenda = await httpService.UpdateAsync(id, venda);

        if (updatedVenda == null)
            return NotFound();
        
        return Ok(updatedVenda);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVenda(Guid id)
    {
        var success = await httpService.DeleteAsync(id);

        if (!success)
            return NotFound();
        
        return NoContent();
    }
}