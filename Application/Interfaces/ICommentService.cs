using Instagram.Models;

namespace Instagram.Interfaces;

public interface ICommentService
{
    Task<Comment?> FindCommentById(int id);
    Task<List<Comment>> GetCommentsByStoryId(int storyId);
    Task<List<Comment>> GetCommentsByUserId(int userId);
    Task CreateComment(Comment comment);
    Task UpdateComment(Comment currentComment, Comment updateComment);
    Task RemoveComment(Comment comment);
}