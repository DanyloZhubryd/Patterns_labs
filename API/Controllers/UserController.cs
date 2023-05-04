using AutoMapper;
using Instagram.DTO;
using Instagram.Models;
using Instagram.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public UserController(IUserService service, IMapper mapper)
    {
        _userService = service;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAll();
        var response = _mapper.Map<List<UserDTO>>(users);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.Find(id);
        if (user is null)
            return NotFound();

        var response = _mapper.Map<UserDTO>(user);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto userDTO)
    {
        var user = _mapper.Map<User>(userDTO);
        await _userService.Create(user);

        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, userDTO);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, CreateUserDto updatedUserDTO)
    {
        var pizza = await _userService.Find(id);
        if (pizza is null)
            return NotFound();

        var updatedUser = _mapper.Map<User>(updatedUserDTO);
        await _userService.Update(pizza, updatedUser);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var pizza = await _userService.Find(id);
        if (pizza is null)
            return NotFound();

        await _userService.Delete(pizza);

        return NoContent();
    }
}

