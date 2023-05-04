using Instagram.Data;
using Instagram.Models;
using Instagram.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services;

public class StoryService : IStoryService
{
    private readonly InstagramContext _context;

    public StoryService(InstagramContext context)
    {
        _context = context;
    }

    public async Task<Story?> FindById(int id) => await _context.StoryCollection.FindAsync(id);

    public async Task<List<Story>> GetAll() => await _context.StoryCollection.ToListAsync();

    public async Task<List<Story>> GetAllByUserId(int userId)
    {
        return await _context.StoryCollection
        .Where(x => x.UserId == userId)
        .ToListAsync();
    }

    public async Task Create(Story story)
    {
        await _context.StoryCollection.AddAsync(story);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Story story)
    {
        _context.StoryCollection.Remove(story);
        await _context.SaveChangesAsync();
    }
}