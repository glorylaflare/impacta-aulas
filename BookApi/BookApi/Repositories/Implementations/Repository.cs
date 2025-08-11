using BookApi.Data;
using BookApi.Models;
using BookApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApiBookContext _context;

    public Repository(ApiBookContext context)
    {
        _context = context;
    }

    public async Task<T?> GetByIdAsync(int id)
{
        var entity = await _context.Set<T>().FindAsync(id);
        return entity;
    }

    public Task Create(T entity)
    {
        _context.Set<T>().Add(entity);
        return Task.FromResult(entity);
    }

    public Task Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return Task.FromResult(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null) return false;
        _context.Set<T>().Remove(entity);
        return true;
    }
}
