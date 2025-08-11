using BookApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos.Autor;

public class AutorReadDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string? Nacionalidade { get; set; }
    public ICollection<AutorComLivroReadDto>? Livros { get; set; }
}
