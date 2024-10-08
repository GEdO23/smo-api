namespace smo_api.Models;

public class Produto
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Estoque { get; set; }
    public string Descricao { get; set; }

    public Produto(long id, string nome, double preco, int estoque, string descricao)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
        Descricao = descricao;
    }
}