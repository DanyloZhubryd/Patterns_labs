using AutoMapper;
using Instagram.DTO;
using Instagram.Models;
using Instagram.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers;

[ApiController]
[Route("story/{storyId}/[controller]")]
public class ReactionController : ControllerBase
{
    private readonly IReactionService _reactionService;
    private readonly IStoryService _storyService;
    private readonly IMapper _mapper;

    public ReactionController(IReactionService reactionService,
                            IStoryService storyService, IMapper mapper)
    {
        _reactionService = reactionService;
        _storyService = storyService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReactionsUnderStory(int storyId)
    {
        var story = await _storyService.FindById(storyId);
        if (story is null)
            return NotFound();

        var reactions = await _reactionService.GetAllByStoryId(storyId);
        var response = _mapper.Map<List<ReactionDTO>>(reactions);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReactionUnderStoryById(int storyId, int id)
    {
        var reaction = await _reactionService.FindByIdAndStoryId(id, storyId);
        if (reaction is null)
            return NotFound();

        var response = _mapper.Map<ReactionDTO>(reaction);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReactionUnderStory(int storyId, CreateReactionDTO reactionDTO)
    {
        if (reactionDTO.StoryId != storyId)
            return BadRequest();

        var reaction = _mapper.Map<Reaction>(reactionDTO);
        await _reactionService.Create(reaction);

        return CreatedAtAction(nameof(GetReactionUnderStoryById), new { storyId = reaction.Id, id = reaction.Id }, reactionDTO);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReactionunderStory(int storyId, int id, CreateReactionDTO updateReactionDTO)
    {
        var currentReaction = await _reactionService.FindByIdAndStoryId(id, storyId);
        if (currentReaction is null)
            return NotFound();

        var updatedReaction = _mapper.Map<Reaction>(updateReactionDTO);
        await _reactionService.Update(currentReaction, updatedReaction);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReactionUnderStory(int storyId, int id)
    {
        var reaction = await _reactionService.FindByIdAndStoryId(id, storyId);
        if (reaction is null)
            return NotFound();

        await _reactionService.Delete(reaction);

        return NoContent();
    }

}