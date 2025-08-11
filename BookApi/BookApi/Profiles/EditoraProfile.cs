using AutoMapper;
using BookApi.Dtos.Editora;
using BookApi.Models;

namespace BookApi.Profiles
{
    public class EditoraProfile : Profile
    {
        public EditoraProfile()
        {
            CreateMap<EditoraCreateDto, EditoraModel>();
            CreateMap<EditoraUpdateDto, EditoraModel>();
            CreateMap<EditoraModel, EditoraReadDto>();
            CreateMap<EditoraModel, EditoraCreateDto>();


            CreateMap<LivroModel, EditoraComLivroReadDto>()
                .ForMember(d => d.GeneroNome, o => o.MapFrom(f => f.Genero.Nome))
                .ForMember(d => d.AutorNome, o => o.MapFrom(f => f.Autor.Nome));
        }
    }
}
