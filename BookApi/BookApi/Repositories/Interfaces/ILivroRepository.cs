using BookApi.Models;

namespace BookApi.Repositories.Interfaces
{
    public interface ILivroRepository : IRepository<LivroModel>
    {
        Task<IEnumerable<LivroModel>> GetAllLivrosWithNames(); // Método : GET -> Esp. Livro
        Task<LivroModel?> GetLivroById(int id); // Método : GET -> Esp. Livro
    }
}
