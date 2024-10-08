using Domain.Interfaces.Data;
using Domain.Interfaces.Models;
using MongoDB.Driver;

namespace Domain.Models.Repositories;

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

    public async Task<IProdutoModel> GetProdutoByIdAsync(string id)
    {
        return await _produtos.Find(prod => prod.Id == id).FirstOrDefaultAsync();
        ;
    }

    public async Task CreateProdutoAsync(IProdutoModel produto)
    {
        await _produtos.InsertOneAsync((ProdutoModel)produto);
    }

    public async Task UpdateProdutoAsync(string id, IProdutoModel produtoIn)
    {
        produtoIn.Id = id;
        await _produtos.ReplaceOneAsync(prod => prod.Id == id, (ProdutoModel)produtoIn);
    }

    public async Task DeleteProdutoAsync(string id)
    {
        await _produtos.DeleteOneAsync(prod => prod.Id == id);
    }
}