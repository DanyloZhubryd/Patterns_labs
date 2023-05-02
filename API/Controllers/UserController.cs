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
    public async Task<List<UserDTO>> GetAll()
    {
        var users = await _userService.GetAll();
        return _mapper.Map<List<User>, List<UserDTO>>(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> Get(int id)
    {
        var user = await _userService.Find(id);
        if (user is null)
            return NotFound();

        return _mapper.Map<UserDTO>(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDTO userDTO)
    {
        var user = _mapper.Map<User>(userDTO);
        await _userService.Create(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UserDTO updatedUserDTO)
    {
        var pizza = await _userService.Find(id);
        if (pizza is null)
            return NotFound();

        var updatedUser = _mapper.Map<User>(updatedUserDTO);
        await _userService.Update(pizza, updatedUser);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pizza = await _userService.Find(id);
        if (pizza is null)
            return NotFound();

        await _userService.Delete(pizza);

        return NoContent();
    }
}

