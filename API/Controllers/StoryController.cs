using AutoMapper;
using Instagram.DTO;
using Instagram.Models;
using Instagram.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers;

[ApiController]
[Route("[controller]")]
public class StoryController : ControllerBase
{
    private readonly IStoryService _storyService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public StoryController(IStoryService storyService, IUserService userService, IMapper mapper)
    {
        _storyService = storyService;
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStories()
    {
        var stories = await _storyService.GetAll();
        var response = _mapper.Map<List<StoryDTO>>(stories);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStoryById(int id)
    {
        var story = await _storyService.FindById(id);
        if (story is null)
            return NotFound();

        var response = _mapper.Map<StoryDTO>(story);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeteleStory(int id)
    {
        var story = await _storyService.FindById(id);
        if (story is null)
            return NotFound();

        await _storyService.Delete(story);

        return NoContent();
    }

    [HttpGet]
    [Route("~/user/{userId}/story")]
    public async Task<IActionResult> GetAllStoriesByUserId(int userId)
    {
        var user = await _userService.Find(userId);
        if (user is null)
            return NotFound();

        var stories = await _storyService.GetAllByUserId(userId);
        var response = _mapper.Map<List<StoryDTO>>(stories);

        return Ok(response);
    }

    [HttpPost]
    [Route("~/user/{userId}/story")]
    public async Task<IActionResult> CreateStory(int userId, CreateStoryDTO storyDTO)
    {
        if (storyDTO.UserId != userId)
            return BadRequest();

        var user = await _userService.Find(userId);
        if (user is null)
            return NotFound();

        var story = _mapper.Map<Story>(storyDTO);
        await _storyService.Create(story);

        return CreatedAtAction(nameof(GetStoryById), new { userId = user.Id, id = story.Id }, storyDTO);
    }
}