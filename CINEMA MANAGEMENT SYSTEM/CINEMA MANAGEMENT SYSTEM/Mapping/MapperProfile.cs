using AutoMapper;
using CINEMA_MANAGEMENT_SYSTEM.DTOs;
using CINEMA_MANAGEMENT_SYSTEM.Models;

namespace CINEMA_MANAGEMENT_SYSTEM.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Genre, EndPoint6DTO>()
                .ForMember(
                x => x.Movies,
                x => x.MapFrom(src => src.Movies)
                );
            CreateMap<CreateGenreDTO, Genre>();
            CreateMap<UpdateGenreDTO, Genre>();


            CreateMap<Movie, MovieDTOEndPoint1>();
            CreateMap<CreateMovieDTOEndPoint3, Movie>();
            CreateMap<UpdateMovieDTOEndPoint4, Movie>();
        }
    }
}
