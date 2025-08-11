namespace MiniCatalogo.Core.Interfaces;

public interface IProductRepository
{
    /// <summary>
    /// Asynchronously adds a new product to the repository.
    /// </summary>
    /// <param name="product">The product entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(Product product);
}
