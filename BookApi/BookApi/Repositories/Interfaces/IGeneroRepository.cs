using BookApi.Models;

namespace BookApi.Repositories.Interfaces
{
    public interface IGeneroRepository : IRepository<GeneroModel>
    {
        Task<IEnumerable<GeneroModel>> GetAllGenerosWithLivros(); // Método : GET -> Esp. Livro
        Task<GeneroModel?> GetGeneroWithLivro(int id); // Método : GET
    }
}
