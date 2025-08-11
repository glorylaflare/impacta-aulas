using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaTreino.Models
{
    public class Emprestimo
    {
        [Key]
        public int EmprestimoId { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("Livro")]
        public int LivroId { get; set; }
        public Livro Livro { get; set; }

        public DateTime DataEmprestimo { get; set; } = DateTime.Now;

        public DateTime? DataDevolucao { get; set; }
    }
}
