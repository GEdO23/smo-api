namespace Domain.Interfaces.Models;

public interface IProdutoModel
{
    string Id { get; set; }
    string Nome { get; set; }
    double Preco { get; set; }
    int Estoque { get; set; }
    string? Descricao { get; set; }
}