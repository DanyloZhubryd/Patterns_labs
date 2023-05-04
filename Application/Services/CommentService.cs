using Instagram.Data;
using Instagram.Models;
using Instagram.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services;

public class CommentService : ICommentService
{
    private readonly InstagramContext _context;

    public CommentService(InstagramContext context)
    {
        _context = context;
    }

    public async Task<Comment?> FindByIdAndStoryId(int id, int storyId)
    {
        return await _context.CommentCollection
            .FirstOrDefaultAsync(x => (x.Id == id) & (x.StoryId == storyId))
            ?? null;
    }

    public async Task<List<Comment>> GetAllByStoryId(int storyId)
    {
        return await _context.CommentCollection
            .Where(x => (x.StoryId == storyId))
            .ToListAsync();
    }

    public async Task Create(Comment comment)
    {
        await _context.CommentCollection.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Comment currentComment, Comment updatedComment)
    {
        currentComment.update(updatedComment);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Comment comment)
    {
        _context.CommentCollection.Remove(comment);
        await _context.SaveChangesAsync();
    }
}