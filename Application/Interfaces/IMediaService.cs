using Instagram.Models;

namespace Instagram.Interfaces;

public interface IMediaService
{
    Task<Media?> FindMediaById(int id);
    Task<Media?> FindMediaByStoryId(int storyId);
    Task CreateMedia(Media media);
    Task<Media?> UpdateMedia(Media currentMedia, Media updatedMedia);
}