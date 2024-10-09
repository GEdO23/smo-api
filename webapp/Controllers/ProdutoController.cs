using Domain.Interfaces.Data;
using Domain.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace webapp.Controllers;

public class ProdutoController : Controller
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var produtos = await _produtoRepository.GetProdutosAsync();
        return View(produtos);
    }

    [HttpGet("/Produto/Cadastrar")]
    public IActionResult FormCadastro()
    {
        return View();
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> Create(ProdutoModel produto)
    {
        await _produtoRepository.CreateProdutoAsync(produto);
        return RedirectToAction("Index");
    }

    [HttpGet("/Produto/Detalhes/{id}")]
    public async Task<IActionResult> Detalhes(string id)
    {
        var produto = await _produtoRepository.GetProdutoByIdAsync(id);
        return View(produto);
    }

    // DELETE
    [HttpPost("/Produto/Deletar/{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _produtoRepository.DeleteProdutoAsync(id);
        return RedirectToAction("Index");
    }
}