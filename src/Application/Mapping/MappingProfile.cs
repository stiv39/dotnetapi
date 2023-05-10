using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Todo, TodoDto>().ReverseMap();
        }
    }
}
