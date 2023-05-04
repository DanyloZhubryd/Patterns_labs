using Instagram.Data;
using Instagram.Models;
using Instagram.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services;

public class ReactionService : IReactionService
{
    private readonly InstagramContext _context;

    public ReactionService(InstagramContext context)
    {
        _context = context;
    }

    public async Task<Reaction?> FindByIdAndStoryId(int id, int storyId)
    {
        return await _context.ReactionCollection
            .FirstOrDefaultAsync(x => (x.Id == id) & (x.StoryId == storyId))
            ?? null;
    }

    public async Task<List<Reaction>> GetAllByStoryId(int storyId)
    {
        return await _context.ReactionCollection
            .Where(x => (x.StoryId == storyId))
            .ToListAsync();
    }

    public async Task Create(Reaction reaction)
    {
        await _context.ReactionCollection.AddAsync(reaction);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Reaction currentReaction, Reaction updatedReaction)
    {
        currentReaction.update(updatedReaction);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Reaction reaction)
    {
        _context.ReactionCollection.Remove(reaction);
        await _context.SaveChangesAsync();
    }
}