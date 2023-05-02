// using instagram_story.Repository;
// using instagram_story.Entities;
// using Microsoft.EntityFrameworkCore;

// namespace instagram_story.Services;

// public class ReactionService : IReactionService
// {
//     private readonly StoryContext _context;

//     public ReactionService(StoryContext context)
//     {
//         _context = context;
//     }

//     public async Task<Reaction?> FindReactionById(int id) => await _context.ReactionCollection.FindAsync(id);

//     public async Task<Reaction?> FindReactionByStoryIdAndUserId(int storyId, int userId)
//     {
//         var reaction = await _context.ReactionCollection
//         .FirstOrDefaultAsync(x => (x.Story.Id == storyId)
//         & (x.User.Id == userId)) ?? null;
//         return reaction;

//     }
//     public async Task<List<Reaction>?> GetReactionsByStoryId(int storyId)
//     {
//         var story = await _context.StoryCollection.FindAsync(storyId);
//         if (story is null)
//             return null;

//         return story.ReactionCollection.ToList();
//     }

//     public async Task CreateReaction(Reaction reaction)
//     {
//         await _context.ReactionCollection.AddAsync(reaction);
//         await _context.SaveChangesAsync();
//     }

//     public async Task<Reaction?> UpdateReaction(int id, Reaction updatedReaction)
//     {
//         var currentReaction = await FindReactionById(id);
//         if (currentReaction is null)
//             return null;
        
//         currentReaction.update(updatedReaction);
//         await _context.SaveChangesAsync();
//         return currentReaction;
//     }

//     public async Task<Reaction?> RemoveReaction(int id)
//     {
//         var reaction = await FindReactionById(id);
//         if (reaction is null)
//             return null;
        
//         _context.ReactionCollection.Remove(reaction);
//         await _context.SaveChangesAsync();
//         return reaction;
//     }
// }