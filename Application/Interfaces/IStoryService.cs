using Instagram.Models;

namespace Instagram.Interfaces;

public interface IStoryService
{
    Task<Story?> FindById(int id);
    Task<List<Story>> GetAll();
    Task<List<Story>> GetAllByUserId(int userId);
    Task Create(Story story);
    Task Delete(Story story);
}