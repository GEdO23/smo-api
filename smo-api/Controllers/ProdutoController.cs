using Domain.Interfaces.Data;
using Domain.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace smo_api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var produtos = await _produtoRepository.GetProdutosAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(string id)
    {
        var produto = await _produtoRepository.GetProdutoByIdAsync(id);

        if (produto == null)
        {
            return NotFound();
        }

        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProdutoModel produto)
    {
        await _produtoRepository.CreateProdutoAsync(produto);
        return CreatedAtAction(
            nameof(Get),
            new { id = produto.Id },
            produto
        );
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(string id, [FromBody] ProdutoModel newProduto)
    {
        var oldProduto = await _produtoRepository.GetProdutoByIdAsync(id);

        if (oldProduto == null)
        {
            return NotFound();
        }

        await _produtoRepository.UpdateProdutoAsync(id, newProduto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var produto = await _produtoRepository.GetProdutoByIdAsync(id);

        if (produto == null)
        {
            return NotFound();
        }

        await _produtoRepository.DeleteProdutoAsync(id);
        return NoContent();
    }
}