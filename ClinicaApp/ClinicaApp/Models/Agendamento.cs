using System.ComponentModel.DataAnnotations;

namespace ClinicaApp.Models;

public class Agendamento
{
    [Key]
    public int Id { get; set; }
    // Chave Estrangeira
    public string Cliente { get; set; }
    // Chave Estrangeira
    public string Medico { get; set; }
    // Chave Estrangeira
    public string Especialidade { get; set; }
    public DateTime DataConsulta { get; set; }
    // ENUM
    public string TipoAtendimento { get; set; }
}
