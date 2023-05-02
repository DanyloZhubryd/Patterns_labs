using AutoMapper;
using Instagram.DTO;
using Instagram.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}