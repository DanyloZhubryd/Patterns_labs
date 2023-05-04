using Instagram.Models;

namespace Instagram.Interfaces;

public interface IReactionService
{
    Task<Reaction?> FindByIdAndStoryId(int id, int storyId);
    Task<List<Reaction>> GetAllByStoryId(int storyId);
    Task Create(Reaction reaction);
    Task Update(Reaction currentReaction, Reaction updatedReaction);
    Task Delete(Reaction reaction);
}