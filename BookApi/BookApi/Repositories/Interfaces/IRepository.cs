using BookApi.Models;

namespace BookApi.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);  // Método : GET
    Task Create(T entity);  // Método : POST
    Task Update(T entity);  // Método : PUT
    Task<bool> DeleteAsync(int id); // Método : DELETE
}
