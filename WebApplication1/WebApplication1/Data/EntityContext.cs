using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class EntityContext : DbContext
    {
        public EntityContext (DbContextOptions<EntityContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplication1.Models.Student> Student { get; set; } = default!;
        public DbSet<WebApplication1.Models.Grade> Grade { get; set; } = default!;
    }
}
