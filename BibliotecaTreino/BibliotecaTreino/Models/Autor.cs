using System.ComponentModel.DataAnnotations;

namespace BibliotecaTreino.Models
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A nacionalidade é obrigatória.")]
        public string Nacionalidade { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
