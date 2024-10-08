using Domain.Interfaces.Data;
using Domain.Models.Repositories;
using MongoDB.Driver;

namespace Data;

public class ProdutoRepository : IProdutoRepository
{
    private readonly IMongoCollection<ProdutoModel> _produtos;

    public ProdutoRepository(string connectionString, string databaseName, string collectionName)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);
        _produtos = database.GetCollection<ProdutoModel>(collectionName);
    }

    public async Task<List<ProdutoModel>> GetProdutosAsync()
    {
        return await _produtos.Find(prod => true).ToListAsync();
    }

    public async Task<ProdutoModel> GetProdutoByIdAsync(string id)
    {
        return await _produtos.Find(prod => prod.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateProdutoAsync(ProdutoModel produto)
    {
        await _produtos.InsertOneAsync(produto);
    }

    public async Task UpdateProdutoAsync(string id, ProdutoModel produtoIn)
    {
        produtoIn.Id = id;
        await _produtos.ReplaceOneAsync(prod => prod.Id == id, produtoIn);
    }

    public async Task DeleteProdutoAsync(string id)
    {
        await _produtos.DeleteOneAsync(prod => prod.Id == id);
    }
}