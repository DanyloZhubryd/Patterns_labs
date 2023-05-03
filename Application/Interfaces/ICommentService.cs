using Instagram.Models;

namespace Instagram.Interfaces;

public interface ICommentService
{
    Task<Comment?> FindById(int id);
    Task<List<Comment>> GetAllByStoryId(int storyId);
    Task Create(Comment comment);
    Task Update(Comment currentComment, Comment updateComment);
    Task Remove(Comment comment);
}