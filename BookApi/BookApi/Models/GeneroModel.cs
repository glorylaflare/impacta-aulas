using System.ComponentModel.DataAnnotations;

namespace BookApi.Models;

public class GeneroModel
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [MaxLength(50)]
    public string? Nome { get; set; }

    public ICollection<LivroModel> Livros { get; set; }
}
