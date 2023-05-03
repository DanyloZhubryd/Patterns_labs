using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models;

[Table("User")]
public class User
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    
    public virtual ICollection<Story> StoryCollection { get; set; }
    public virtual ICollection<Reaction> ReactionCollection { get; set; }
    public virtual ICollection<Comment> CommentCollection { get; set; }

    internal void update(User updatedUser)
    {
        this.Username = updatedUser.Username;
    }
}