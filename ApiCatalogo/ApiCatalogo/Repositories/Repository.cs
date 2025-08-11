using ApiCatalogo.Data;
using ApiCatalogo.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repositories;

public class Repository : IRepository
{
    private readonly CatalogoContext _context;

    public Repository(CatalogoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync<T>(int id) where T : class
    {
        var entity = await _context.Set<T>().FindAsync(id);
        return entity;
    }

    public Task<T> Create<T>(T entity) where T : class
    {
        _context.Set<T>().Add(entity);
        return Task.FromResult(entity);
    }

    public Task<T> Update<T>(T entity) where T : class
    {
        _context.Set<T>().Update(entity);
        return Task.FromResult(entity);
    }

    public async Task<bool> DeleteAsync<T>(int id) where T : class
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null)
        {
            return false;
        }
        _context.Set<T>().Remove(entity);
        return true;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}