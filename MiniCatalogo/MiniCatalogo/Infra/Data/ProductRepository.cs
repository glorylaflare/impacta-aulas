using MiniCatalogo.Core.Interfaces;

namespace MiniCatalogo.Infra.Data;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product), "Product cannot be null");
        }
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
}
