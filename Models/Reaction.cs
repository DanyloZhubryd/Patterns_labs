using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models;

[Table("Reaction")]
public class Reaction
{
    [Key]
    public int Id { get; set; }
    [Column(TypeName = "int")]
    public ReactionType Type { get; set; }
    
    [ForeignKey("UserId")]
    public int? UserId { get; set; }
    public User? User { get; set; }
    [ForeignKey("StoryId")]
    public int StoryId { get; set; }
    public Story Story { get; set; }

    public enum ReactionType
    {
        LIKE = 1,
        LOVE = 2,
        HAHA = 3,
        WOW = 4,
        SAD = 5,
        ANGRY = 6
    }

    public void update(Reaction updatedReaction)
    {
        this.Type = updatedReaction.Type;
    }
}