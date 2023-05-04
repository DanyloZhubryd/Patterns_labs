using Instagram.Models;

namespace Instagram.Interfaces;

public interface IReactionService
{
    Task<Reaction?> FindReactionById(int id);
    Task<Reaction?> FindReactionByStoryIdAndUserId(int storyId, int userId);
    Task<List<Reaction>> GetReactionsByStoryId(int storyId);
    Task CreateReaction(Reaction reaction);
    Task UpdateReaction(Reaction currnetReaction, Reaction updatedReaction);
    Task DeleteReaction(Reaction reaction);
}