using System.ComponentModel.DataAnnotations;

namespace Instagram.DTO;

public class CreateCommentDTO
{
    [Required, StringLength(450)]
    public string Text { get; set; }
    public int? UserId { get; set; }
    [Required]
    public int StoryId { get; set; }
}

public class CommentDTO : CreateCommentDTO
{
    public int Id { get; set; }
}