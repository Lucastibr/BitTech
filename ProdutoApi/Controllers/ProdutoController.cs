using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace ProdutoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController(IService<Produto> httpService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduto(Produto produto)
    {
        try
        {
            await httpService.CreateAsync(produto);

            return Created();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message); 
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProdutoById(Guid id)
    {
        var produto = await httpService.GetByIdAsync(id);

        if (produto == null)
            return NotFound();
        
        return Ok(produto);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProdutos()
    {
        var produtos = await httpService.GetAllAsync();
        return Ok(produtos);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduto(Guid id, Produto produto)
    {
        var updatedProduto = await httpService.UpdateAsync(id, produto);

        if (updatedProduto == null)
            return NotFound();
        
        return Ok(updatedProduto);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(Guid id)
    {
        var success = await httpService.DeleteAsync(id);

        if (!success)
            return NotFound();
        
        return NoContent();
    }
}