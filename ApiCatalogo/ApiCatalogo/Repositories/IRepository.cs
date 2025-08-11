using ApiCatalogo.Model;
using System.Linq.Expressions;

namespace ApiCatalogo.Repositories;

public interface IRepository
{
    Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
    Task<T?> GetByIdAsync<T>(int id) where T : class;
    Task<T> Create<T>(T entity) where T : class;
    Task<T> Update<T>(T entity) where T : class;
    Task<bool> DeleteAsync<T>(int id) where T : class;
    Task<bool> SaveChangesAsync();
}
