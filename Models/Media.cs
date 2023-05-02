using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Instagram.Models;

[Table("Media")]
public class Media
{
    [Key]
    public int Id { get; set; }
    [DataType(DataType.ImageUrl)]
    public string Url { get; set; }
    [ForeignKey("StoryId")]
    public Story Story;

    public void update(Media updateMedia)
    {
        this.Url = updateMedia.Url;
    }
}