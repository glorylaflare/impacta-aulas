using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos.Autor;

public class AutorUpdateDto
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(255, ErrorMessage = "O campo não pode ter mais que 255 caracteres.")]
    public string? Nome { get; set; }

    public DateOnly DataNascimento { get; set; }

    [StringLength(100, ErrorMessage = "O campo não pode ter mais que 100 caracteres.")]
    public string? Nacionalidade { get; set; }
}
