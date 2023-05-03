using System.ComponentModel.DataAnnotations;

namespace Instagram.DTO;

public class CreateUserDto
{
    [Required, StringLength(50)]
    public string Username { get; set; }
}

public class UserDTO : CreateUserDto
{
    public int Id { get; set; }
}