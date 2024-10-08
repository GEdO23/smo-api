using Domain.Interfaces.Models;
using Domain.Models.Repositories;

namespace Domain.Interfaces.Data;

public interface IProdutoRepository
{
    Task<List<ProdutoModel>> GetProdutosAsync();
    Task<IProdutoModel> GetProdutoByIdAsync(string id);
    Task CreateProdutoAsync(IProdutoModel produto);
    Task UpdateProdutoAsync(string id, IProdutoModel produtoIn);
    Task DeleteProdutoAsync(string id);
}