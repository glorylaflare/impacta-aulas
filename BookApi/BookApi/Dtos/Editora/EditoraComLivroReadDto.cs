namespace BookApi.Dtos.Editora
{
    public class EditoraComLivroReadDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Isbn { get; set; }
        public DateOnly AnoPublicacao { get; set; }

        public string GeneroNome { get; set; }
        public string AutorNome { get; set; }
    }
}
