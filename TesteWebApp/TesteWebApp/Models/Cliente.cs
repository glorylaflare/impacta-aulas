using System.ComponentModel.DataAnnotations.Schema;

namespace TesteWebApp.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        [ForeignKey("Medico")]
        public int MedicoId { get; set; }
    }
}
