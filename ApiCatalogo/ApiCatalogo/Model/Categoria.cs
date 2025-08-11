using System.Collections.ObjectModel;

namespace ApiCatalogo.Model;

public class Categoria
{
    public int CategoriaId { get; set; }
    public string? Nome { get; set; }
    public string? ImagemUrl { get; set; }

    // One-To-Many relationship with Produto
    public ICollection<Produto> Produtos { get; set; } = new Collection<Produto>();
}
