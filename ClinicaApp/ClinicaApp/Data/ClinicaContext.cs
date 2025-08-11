using ClinicaApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaApp.Data;

public class ClinicaContext : DbContext
{
    public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options) { }

    // Todas as tabelas do banco de dados
    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Agendamento> Agendamentos { get; set; }
}
