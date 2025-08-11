using BookApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos.Editora;

public class EditoraReadDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Nacionalidade { get; set; }
    public ICollection<EditoraComLivroReadDto>? Livros { get; set; }
}
