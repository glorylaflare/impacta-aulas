using AutoMapper;
using BookApi.Dtos.Livro;
using BookApi.Models;

namespace BookApi.Profiles;

public class LivroProfile : Profile
{
    public LivroProfile() 
    {
        CreateMap<LivroCreateDto, LivroModel>(); // ORIGEM -> DESTINO | d (destino), o (origem), f (fonte)
        CreateMap<LivroUpdateDto, LivroModel>();
        CreateMap<LivroModel, LivroCreateDto>();
        CreateMap<LivroModel, LivroReadDto>()
            .ForMember(d => d.AutorNome, o => o.MapFrom(f => f.Autor.Nome))
            .ForMember(d => d.GeneroNome, o => o.MapFrom(f => f.Genero.Nome))
            .ForMember(d => d.EdidoraNome, o => o.MapFrom(f => f.Edidora.Nome));
    }
}
