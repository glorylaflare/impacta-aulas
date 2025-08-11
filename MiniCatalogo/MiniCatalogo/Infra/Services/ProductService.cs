using MiniCatalogo.Core.Interfaces;

namespace MiniCatalogo.Infra.Services;

// Versão inicial, ainda com o problema do OCP
public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    // Depende da ABSTRAÇÃO, não da implementação! (DIP)
    public ProductService(IProductRepository productRepository)
    {
        _repository = productRepository;
    }

    public async Task<Product> CreateProductAsync(string name, decimal price, string type)
    {
        // Responsabilidade Única: orquestrar a criação de um produto
        if (string.IsNullOrEmpty(name) || price <= 0)
        {
            throw new ArgumentException("Dados do produto inválidos.");
        }

        // A lógica de desconto ainda está aqui, vamos resolver em seguida
        decimal finalPrice = price;
        if (type == "Eletrônico") { finalPrice *= 0.9m; }
        else if (type == "Vestuário") { finalPrice *= 0.8m; }

        var product = new Product { Name = name, Price = finalPrice, Type = type };

        await _repository.AddAsync(product);

        // A responsabilidade de LOG foi removida daqui.
        // Poderia ser colocada em um serviço de notificação, por exemplo.

        return product;
    }
}
