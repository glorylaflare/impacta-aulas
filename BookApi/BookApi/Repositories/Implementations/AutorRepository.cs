using BookApi.Data;
using BookApi.Models;
using BookApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repositories.Implementations
{
    public class AutorRepository : Repository<AutorModel>, IAutorRepository
    {
        private readonly ApiBookContext _context;

        public AutorRepository(ApiBookContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<AutorModel> QueryComRelacionamentoAutor()
        {
            return _context.Autores
                .Include(a => a.Livros)
                    .ThenInclude(l => l.Genero)
                .Include(a => a.Livros)
                    .ThenInclude(l => l.Edidora);
        }

        public async Task<IEnumerable<AutorModel>> GetAllAutoresWithLivros()
        {
            return await QueryComRelacionamentoAutor().ToListAsync();
        }

        public async Task<AutorModel?> GetAutorWithLivro(int id)
        {
            return await QueryComRelacionamentoAutor().FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
