using BookApi.Repositories.Interfaces;

namespace BookApi.Repositories
{
    public interface IUnitOfWork
    {
        IAutorRepository Autores {  get; }
        ILivroRepository Livros { get; }
        IEditoraRepository Editoras { get; }
        IGeneroRepository Generos { get; }

        Task<bool> SaveChangesAsync();
    }
}
