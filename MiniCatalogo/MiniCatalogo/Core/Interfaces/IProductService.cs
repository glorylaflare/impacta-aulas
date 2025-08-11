namespace MiniCatalogo.Core.Interfaces;

public interface IProductService
{
    /// <summary>
    /// Asynchronously creates a new product in the catalog.
    /// </summary>
    /// <param name="product">The product entity to be created.</param>
    /// <returns>The created <see cref="Product"/> instance with updated properties (e.g., Id).</returns>
    Task<Product> CreateProductAsync(string name, decimal price, string type);
}
