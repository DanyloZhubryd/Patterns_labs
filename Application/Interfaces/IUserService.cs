using Instagram.Models;

namespace Instagram.Interfaces;

public interface IUserService
{
    Task<User?> Find(int id);
    Task<List<User>> GetAll();
    Task Create(User user);
    Task Update(User currentUser, User updatedUser);
    Task Delete(User user);
}