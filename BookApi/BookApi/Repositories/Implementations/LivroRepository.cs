using BookApi.Data;
using BookApi.Models;
using BookApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repositories.Implementations
{
    public class LivroRepository : Repository<LivroModel>, ILivroRepository
    {
        private readonly ApiBookContext _context;

        public LivroRepository(ApiBookContext context) : base(context) 
        {
            _context = context;
        }

        private IQueryable<LivroModel> QueryComRelacionamentoLivro()
        {
            return _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Edidora)
                .Include(l => l.Genero);
        }

        public async Task<IEnumerable<LivroModel>> GetAllLivrosWithNames()
        {
            return await QueryComRelacionamentoLivro().ToListAsync();
        }

        public async Task<LivroModel?> GetLivroById(int id)
        {
            return await QueryComRelacionamentoLivro().FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
