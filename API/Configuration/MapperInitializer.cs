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

        CreateMap<Comment, CommentDTO>().ReverseMap();
        CreateMap<Comment, CreateCommentDTO>().ReverseMap();

        CreateMap<Reaction, ReactionDTO>().ReverseMap();
        CreateMap<Reaction, CreateReactionDTO>().ReverseMap();
    }
}