using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookApi.Models;

public class AutorModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [MaxLength(255)]
    public string? Nome { get; set; }

    public DateOnly DataNascimento { get; set; }

    [MaxLength(100)]
    public string? Nacionalidade { get; set; }

    public ICollection<LivroModel> Livros { get; set; } // 1:N
}
