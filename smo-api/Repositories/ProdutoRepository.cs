using MongoDB.Driver;
using smo_api.Models;

namespace smo_api.Repositories;

public class ProdutoRepository
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
}