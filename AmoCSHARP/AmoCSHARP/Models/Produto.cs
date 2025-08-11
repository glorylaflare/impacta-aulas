namespace AmoCSHARP.Models;

public class Produto
{
    public int Id { get; set; }
    public string NomeProduto { get; set; }
    public string NomeDescricao { get; set; }
    public decimal Preco { get; set; } 
    public int Estoque { get; set; }
    public string Categoria { get; set; }
}
