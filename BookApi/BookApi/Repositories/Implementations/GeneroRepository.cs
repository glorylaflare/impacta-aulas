using BookApi.Data;
using BookApi.Models;
using BookApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repositories.Implementations
{
    public class GeneroRepository : Repository<GeneroModel>, IGeneroRepository
    {
        private readonly ApiBookContext _context;

        public GeneroRepository(ApiBookContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GeneroModel>> GetAllGenerosWithLivros()
        {
            return await _context.Generos.ToListAsync();
        }

        public async Task<GeneroModel?> GetGeneroWithLivro(int id)
        {
            return await _context.Generos.FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}
