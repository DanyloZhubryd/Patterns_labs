using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models;

[Table("Comment")]
public class Comment
{
    [Key]
    public int Id { get; set; }
    
    public string Text { get; set; }

    [ForeignKey("UserId")]
    public int? UserId { get; set; }
    public User? User { get; set; }
    [ForeignKey("StoryId")]
    public int StoryId { get; set; }
    public Story Story { get; set; }

    public void update(Comment updatedComment)
    {
        this.Text = updatedComment.Text;
    }
}