using ApiCatalogo.Data;
using ApiCatalogo.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Repositories;

public class CategoriaRepository : Repository, ICategoriaRepository
{
    private readonly CatalogoContext _context;

    public CategoriaRepository(CatalogoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Categoria?> GetCategoriaWithProdutos(int id)
    {
        return await _context.Categorias
            .Include(c => c.Produtos)
            .FirstOrDefaultAsync(c => c.CategoriaId == id);
    }
}
