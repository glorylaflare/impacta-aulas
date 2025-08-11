using BookApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos.Livro;

public class LivroUpdateDto
{
    [StringLength(100, ErrorMessage = "O número de caracteres foi exedido.")]
    public string? Titulo { get; set; }

    [StringLength(17, ErrorMessage = "O número de caracteres foi exedido.")]
    [RegularExpression(@"^97[89]-\d{2}-\d{3}-\d{4}-\d{1}$", ErrorMessage = "O campo ISBN deve estar no formato XXX-XX-XXX-XXXX-X.")]
    public string? ISBN { get; set; }

    public DateOnly AnoPublicacao { get; set; }
}
