using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteWebApp.Models;

namespace TesteWebApp.Data
{
    public class TesteWebAppContext : DbContext
    {
        public TesteWebAppContext (DbContextOptions<TesteWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<TesteWebApp.Models.Medico> Medico { get; set; } = default!;
        public DbSet<TesteWebApp.Models.Especilidade> Especilidade { get; set; } = default!;
        public DbSet<TesteWebApp.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<TesteWebApp.Models.Plano> Plano { get; set; } = default!;
    }
}
