using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace ProdutoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController(IHttpService<Produto> httpService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduto(Produto produto)
    {
        return await httpService.CreateAsync(produto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProdutoById(Guid id)
    {
        return await httpService.GetByIdAsync(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetProdutos()
    {
        return await httpService.GetAllAsync();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduto(Guid id, Produto produto)
    {
        return await httpService.UpdateAsync(id, produto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(Guid id)
    {
        return await httpService.DeleteAsync(id);
    }
}