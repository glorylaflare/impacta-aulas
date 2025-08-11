using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookApi.Models;

public class EditoraModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [MaxLength(100)]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [MaxLength(100)]
    public string? Nacionalidade { get; set; }

    public ICollection<LivroModel> Livros { get; set; }
}
