using BookApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Data;

public class ApiBookContext : DbContext
{
    public ApiBookContext(DbContextOptions<ApiBookContext> options) : base(options)
    {
    }

    public DbSet<AutorModel> Autores { get; set; }
    public DbSet<LivroModel> Livros { get; set; }
    public DbSet<GeneroModel> Generos { get; set; }
    public DbSet<EditoraModel> Editoras { get; set; }
}
