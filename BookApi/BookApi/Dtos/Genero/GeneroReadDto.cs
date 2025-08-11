using BookApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos.Genero;

public class GeneroReadDto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
}
