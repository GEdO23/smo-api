using Domain.Interfaces.Data;
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
}