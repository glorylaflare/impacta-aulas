using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace BookApi.Models;

public class LivroModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [MaxLength(100)]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [MaxLength(17)] // 13 digits + 4 hyphens
    [RegularExpression(@"^97[89]-\d{2}-\d{3}-\d{4}-\d{1}$", ErrorMessage = "O campo ISBN deve estar no formato XXX-XX-XXX-XXXX-X.")]
    public string? ISBN { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public DateOnly AnoPublicacao { get; set; }

    public int GeneroId { get; set; }
    public GeneroModel? Genero { get; set; } // 1:1

    public int EdidoraId { get; set; }
    public EditoraModel? Edidora { get; set; } // 1:1

    public int AutorId { get; set; }
    public AutorModel? Autor { get; set; } // 1:1
}
