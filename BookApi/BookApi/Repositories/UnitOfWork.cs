using BookApi.Data;
using BookApi.Repositories.Implementations;
using BookApi.Repositories.Interfaces;

namespace BookApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiBookContext _context;
        public IAutorRepository Autores { get; }
        public ILivroRepository Livros { get; }
        public IEditoraRepository Editoras { get; }
        public IGeneroRepository Generos { get; }

        public UnitOfWork(ApiBookContext context)
        {
            _context = context;
            Autores = new AutorRepository(_context);
            Livros = new LivroRepository(_context);
            Editoras = new EditoraRepository(_context);
            Generos = new GeneroRepository(_context);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
