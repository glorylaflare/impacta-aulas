using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteWebApp.Models
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CRM { get; set; }
        
        [ForeignKey("Especilidade")]
        public int EspecilidadeId { get; set; }
        
        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}
