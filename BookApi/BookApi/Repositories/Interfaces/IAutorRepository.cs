using BookApi.Models;

namespace BookApi.Repositories.Interfaces
{
    public interface IAutorRepository : IRepository<AutorModel>
    {
        Task<IEnumerable<AutorModel>> GetAllAutoresWithLivros(); // Método : GET -> Esp. Livro
        Task<AutorModel?> GetAutorWithLivro(int id); // Método : GET
    }
}
