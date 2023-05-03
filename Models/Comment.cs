using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models;

[Table("Comment")]
public class Comment
{
    [Key]
    public int Id { get; set; }
    
    public string Text { get; set; }
    
    public int? UserId { get; set; }
    public User? User { get; set; }
    public int StoryId { get; set; }
    public Story Story { get; set; }
}