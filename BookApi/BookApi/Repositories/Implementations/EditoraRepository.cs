using BookApi.Data;
using BookApi.Models;
using BookApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repositories.Implementations
{
    public class EditoraRepository : Repository<EditoraModel>, IEditoraRepository
    {
        private readonly ApiBookContext _context;

        public EditoraRepository(ApiBookContext context) : base(context)
        {
            _context = context;
        }

        private IQueryable<EditoraModel> QueryComRelacionamentoEditora()
        {
            return _context.Editoras
                .Include(e => e.Livros)
                    .ThenInclude(l => l.Autor)
                .Include(e => e.Livros)
                    .ThenInclude(l => l.Genero);
        }

        public async Task<IEnumerable<EditoraModel>> GetAllEditorasWithLivros()
        {
            return await QueryComRelacionamentoEditora().ToListAsync();
        }

        public async Task<EditoraModel?> GetEditoraWithLivro(int id)
        {
            return await QueryComRelacionamentoEditora().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
