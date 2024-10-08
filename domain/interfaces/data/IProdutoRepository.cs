using Domain.Models.Repositories;

namespace Domain.Interfaces.Data;

public interface IProdutoRepository
{
    Task<List<ProdutoModel>> GetProdutosAsync();
    Task<ProdutoModel> GetProdutoByIdAsync(string id);
    Task CreateProdutoAsync(ProdutoModel produto);
    Task UpdateProdutoAsync(string id, ProdutoModel produtoIn);
    Task DeleteProdutoAsync(string id);
}