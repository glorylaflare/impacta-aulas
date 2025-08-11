using BookApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos.Livro;

public class LivroCreateDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O número de caracteres foi exedido.")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(17, ErrorMessage = "O número de caracteres foi exedido.")]
    [RegularExpression(@"^97[89]-\d{2}-\d{3}-\d{4}-\d{1}$", ErrorMessage = "O campo ISBN deve estar no formato XXX-XX-XXX-XXXX-X.")]
    public string? ISBN { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public DateOnly AnoPublicacao { get; set; }

    public int GeneroId { get; set; }
    public int EdidoraId { get; set; }
    public int AutorId { get; set; }
}
