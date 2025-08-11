using System.ComponentModel.DataAnnotations;

namespace MiniProjetoEntregas.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; } = DateTime.Now;
    }
}
