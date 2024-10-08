using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace smo_api.Models;

public class ProdutoModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public required string Id { get; set; }
    
    [BsonElement("nome")]
    public required string Nome { get; set; }
    
    [BsonElement("preco")]
    public required double Preco { get; set; }
    
    [BsonElement("estoque")]
    public required int Estoque { get; set; }
    
    [BsonElement("descricao")]
    public string? Descricao { get; set; }
}