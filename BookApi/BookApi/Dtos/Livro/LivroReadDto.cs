using BookApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos.Livro;

public class LivroReadDto
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? ISBN { get; set; }
    public DateOnly AnoPublicacao { get; set; }
    public string? GeneroNome { get; set; } 
    public string? EdidoraNome { get; set; } 
    public string? AutorNome { get; set; } 
}
