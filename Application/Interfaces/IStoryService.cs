using Instagram.Models;

namespace Instagram.Interfaces;

public interface IStoryService
{
    Task<Story?> FindById(int id);
    Task<List<Story>> GetByUserId(int userId);
    Task Create(Story story);
    Task UpdateStory(Story currentStory, Story updateStory);
    Task DeleteStoryById(Story story);
}