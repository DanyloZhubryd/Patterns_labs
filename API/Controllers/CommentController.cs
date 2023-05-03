using AutoMapper;
using Instagram.DTO;
using Instagram.Models;
using Instagram.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers;

[ApiController]
[Route("story/{storyId}/[controller]")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly IStoryService _storyService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public CommentController(ICommentService commentService, IStoryService storyService,
                            IUserService userService, IMapper mapper)
    {
        _commentService = commentService;
        _storyService = storyService;
        _userService = userService;
        _mapper = mapper;
    }

    
}