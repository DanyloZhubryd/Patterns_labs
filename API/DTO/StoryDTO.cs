using System.ComponentModel.DataAnnotations;

namespace Instagram.DTO;

public class CreateStoryDTO
{
    [StringLength(150)]
    public string? Caption { get; set; }
    [Required, DataType(DataType.ImageUrl)]
    public string MediaUrl { get; set; }
    public bool IsCloseFriendsOnly { get; set; }
    [Required]
    public int UserId { get; set; }
}

public class StoryDTO : CreateStoryDTO
{
    public int Id { get; set; }
}