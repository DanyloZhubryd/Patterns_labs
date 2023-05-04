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
    private readonly IMapper _mapper;

    public CommentController(ICommentService commentService,
                            IStoryService storyService, IMapper mapper)
    {
        _commentService = commentService;
        _storyService = storyService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCommentsUnderStory(int storyId)
    {
        var story = await _storyService.FindById(storyId);
        if (story is null)
            return NotFound();

        var comments = await _commentService.GetAllByStoryId(storyId);
        var response = _mapper.Map<List<CommentDTO>>(comments);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentUnderStoryById(int storyId, int id)
    {
        var comment = await _commentService.FindByIdAndStoryId(id, storyId);
        if (comment is null)
            return NotFound();

        var response = _mapper.Map<CommentDTO>(comment);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCommentUnderStory(int storyId, CreateCommentDTO commentDTO)
    {
        if (commentDTO.StoryId != storyId)
            return BadRequest();

        var comment = _mapper.Map<Comment>(commentDTO);
        await _commentService.Create(comment);

        return CreatedAtAction(nameof(GetCommentUnderStoryById), new { storyId = comment.Id, id = comment.Id }, commentDTO);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCommentunderStory(int storyId, int id, CreateCommentDTO updateCommentDTO)
    {
        var currentComment = await _commentService.FindByIdAndStoryId(id, storyId);
        if (currentComment is null)
            return NotFound();

        var updatedComment = _mapper.Map<Comment>(updateCommentDTO);
        await _commentService.Update(currentComment, updatedComment);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommentUnderStory(int storyId, int id)
    {
        var comment = await _commentService.FindByIdAndStoryId(id, storyId);
        if (comment is null)
            return NotFound();

        await _commentService.Delete(comment);

        return NoContent();
    }

}