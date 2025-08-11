using System.ComponentModel.DataAnnotations;

namespace ApiCatalogo.Model;

public class Transacao
{
    [Key]
    public int TransacaoId { get; set; }
    public int Quantidade { get; set; }
    public decimal Valor
    {
        get => (Produto?.Preco ?? 0) * this.Quantidade;
        set { /* Valor é calculado, não deve ser setado diretamente */ }
    }
    public int ProdutoId { get; set; }
    public Produto Produto { get; set; }
}
