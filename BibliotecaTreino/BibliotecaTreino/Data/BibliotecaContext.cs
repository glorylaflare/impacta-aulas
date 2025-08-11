using BibliotecaTreino.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaTreino.Data
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
            : base(options) {}
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }
}
