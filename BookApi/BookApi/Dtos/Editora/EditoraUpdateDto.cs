using BookApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos.Editora;

public class EditoraUpdateDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres.")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo deve ter no máximo 100 caracteres.")]
    public string? Nacionalidade { get; set; }

    public ICollection<LivroModel>? Livros { get; set; }
}
