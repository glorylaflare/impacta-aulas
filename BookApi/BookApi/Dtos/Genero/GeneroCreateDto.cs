using BookApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos.Genero;

public class GeneroCreateDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(50, ErrorMessage = "O cmapo deve ter no máximo 50 caracteres.")]
    public string? Nome { get; set; }

    public ICollection<LivroModel>? Livros { get; set; }
}
