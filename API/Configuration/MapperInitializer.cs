using AutoMapper;
using Instagram.DTO;
using Instagram.Models;

public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, CreateUserDto>().ReverseMap();

        CreateMap<Story, StoryDTO>().ReverseMap();
        CreateMap<Story, CreateStoryDTO>().ReverseMap();
    }
}