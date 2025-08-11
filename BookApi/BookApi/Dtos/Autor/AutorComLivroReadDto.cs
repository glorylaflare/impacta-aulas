namespace BookApi.Dtos.Autor;

public class AutorComLivroReadDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Isbn { get; set; }
    public DateOnly AnoPublicacao { get; set; }

    public string GeneroNome { get; set; }
    public string EditoraNome { get; set; }
}
