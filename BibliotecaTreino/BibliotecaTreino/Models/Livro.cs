using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaTreino.Models
{
    public class Livro
    {
        [Key]
		public int LivroId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "O titulo é obrigatório.")]
        public string Titulo { get; set; }

        [ForeignKey("Autor")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        [Required(ErrorMessage = "O ISBN é obrigatório.")]
        public string Isbn { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "A quantidade de estoque é obrigatória.")]
        public short QntEstoque { get; set; }
    }
}
