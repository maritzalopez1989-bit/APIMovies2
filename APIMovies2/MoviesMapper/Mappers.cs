
using APIMovies2.DAL.Models;
using APIMovies2.DAL.Models.Dtos;
using AutoMapper;

namespace APIMovies2.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap(); 
        }
    }

}
