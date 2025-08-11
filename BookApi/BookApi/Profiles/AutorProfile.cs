using AutoMapper;
using BookApi.Dtos.Autor;
using BookApi.Models;

namespace BookApi.Profiles
{
    public class AutorProfile : Profile
    {
        public AutorProfile()
        {
            CreateMap<AutorCreateDto, AutorModel>();
            CreateMap<AutorUpdateDto, AutorModel>();
            CreateMap<AutorModel, AutorReadDto>();
            CreateMap<AutorModel, AutorCreateDto>();

            CreateMap<LivroModel, AutorComLivroReadDto>()
                .ForMember(d => d.GeneroNome, o => o.MapFrom(f => f.Genero.Nome))
                .ForMember(d => d.EditoraNome, o => o.MapFrom(f => f.Edidora.Nome));
        }
    }
}
