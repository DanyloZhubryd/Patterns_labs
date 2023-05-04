using Instagram.Models;

namespace Instagram.Interfaces;

public interface ICommentService
{
    Task<Comment?> FindByIdAndStoryId(int id, int storyId);
    Task<List<Comment>> GetAllByStoryId(int storyId);
    Task Create(Comment comment);
    Task Update(Comment currentComment, Comment updatedComment);
    Task Delete(Comment comment);
}