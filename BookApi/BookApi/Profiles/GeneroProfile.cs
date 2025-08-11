using AutoMapper;
using BookApi.Dtos.Genero;
using BookApi.Models;

namespace BookApi.Profiles
{
    public class GeneroProfile : Profile
    {
        public GeneroProfile()
        {
            CreateMap<GeneroCreateDto, GeneroModel>();
            CreateMap<GeneroUpdateDto, GeneroModel>();
            CreateMap<GeneroModel, GeneroReadDto>();
            CreateMap<GeneroModel, GeneroCreateDto>();
        }
    }
}
