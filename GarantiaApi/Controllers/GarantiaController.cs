using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace GarantiaApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GarantiaController(IService<Garantia> httpService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateGarantia(Garantia garantia)
    {
        try
        {
            await httpService.CreateAsync(garantia);

            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGarantiaById(Guid id)
    {
        var garantia = await httpService.GetByIdAsync(id);

        if (garantia == null)
            return NotFound();
        
        return Ok(garantia);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGarantias()
    {
        var garantias = await httpService.GetAllAsync();
        return Ok(garantias);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGarantia(Guid id, Garantia garantia)
    {
        var updatedGarantia = await httpService.UpdateAsync(id, garantia);

        if (updatedGarantia == null)
            return NotFound();
        
        return Ok(updatedGarantia);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGarantia(Guid id)
    {
        var success = await httpService.DeleteAsync(id);

        if (!success)
            return NotFound();
        
        return Ok();
    }
}