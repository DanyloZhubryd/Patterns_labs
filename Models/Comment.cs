using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models;

[Table("Comment")]
public class Comment
{
    [Key]
    public int Id { get; set; }
    [Required, StringLength(450)]
    public string Text { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }
    [ForeignKey("StoryId")]
    public Story Story { get; set; }
}