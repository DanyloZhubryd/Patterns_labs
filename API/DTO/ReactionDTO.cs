using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static Instagram.Models.Reaction;

namespace Instagram.DTO;

public class CreateReactionDTO
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ReactionType Type { get; set; }
    public int? UserId { get; set; }
    [Required]
    public int StoryId { get; set; }
}

public class ReactionDTO : CreateReactionDTO
{
    public int Id { get; set; }
}