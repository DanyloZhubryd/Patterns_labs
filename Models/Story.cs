using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models;

[Table("Story")]
public class Story
{
    [Key]
    public int Id { get; set; }
    public string? Caption { get; set; }
    public string MediaUrl { get; set; }
    public bool IsCloseFriendsOnly { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    
    public virtual ICollection<Reaction> ReactionCollection { get; set; }
    public virtual ICollection<Comment> CommentCollection { get; set; }
}