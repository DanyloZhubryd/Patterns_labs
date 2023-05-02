using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models;

[Table("Story")]
public class Story
{
    [Key]
    public int Id { get; set; }
    [StringLength(150)]
    public string? Caption { get; set; }
    public bool IsCloseFriendsOnly { get; set; }
    [Required, ForeignKey("MediaId")]
    public Media Media { get; set; }
    public ICollection<Reaction> ReactionCollection { get; set; }
    public ICollection<Comment> CommentCollection { get; set; }
    [Required, ForeignKey("UserId")]
    public User User { get; set; }
}