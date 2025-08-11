using BookApi.Models;

namespace BookApi.Repositories.Interfaces
{
    public interface IEditoraRepository : IRepository<EditoraModel>
    {
        Task<IEnumerable<EditoraModel>> GetAllEditorasWithLivros(); // Método : GET -> Esp. Livro
        Task<EditoraModel?> GetEditoraWithLivro(int id); // Método : GET
    }
}
