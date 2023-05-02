using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models;

[Table("User")]
public class User
{
    [Key]
    public int Id { get; set; }
    [Required, StringLength(50)]
    public string Username { get; set; }
    public ICollection<Story> StoryCollection { get; set; }
    public ICollection<Reaction> ReactionCollection { get; set; }
    public ICollection<Comment> CommentCollection { get; set; }

    internal void update(User updatedUser)
    {
        this.Username = updatedUser.Username;
    }
}