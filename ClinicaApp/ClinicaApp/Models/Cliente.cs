using System.ComponentModel.DataAnnotations;

namespace ClinicaApp.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Nome do Cliente")]
        public string? Nome { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        [Display(Name = "Salário")]
        public decimal Salario { get; set; }

    }
}
