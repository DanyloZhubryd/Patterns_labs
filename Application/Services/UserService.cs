using Instagram.Data;
using Instagram.Models;
using Instagram.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Instagram.Services;

public class UserService : IUserService
{
    private readonly InstagramContext _context;

    public UserService(InstagramContext context)
    {
        _context = context;
    }

    public async Task<User?> Find(int id) => await _context.UserCollection.FindAsync(id);

    public async Task<List<User>> GetAll() => await _context.UserCollection.ToListAsync();

    public async Task Create(User user)
    {
        await _context.UserCollection.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User currentUser, User updatedUser)
    {
        currentUser.update(updatedUser);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(User user)
    {
        _context.UserCollection.Remove(user);
        await _context.SaveChangesAsync();
    }



}