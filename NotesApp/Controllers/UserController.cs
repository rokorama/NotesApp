using Microsoft.AspNetCore.Mvc;
using NotesApp.Authentication;
using NotesApp.Models;
using NotesAppBusinessLogic;

namespace NotesApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;
    private readonly ILogger _logger;

    public UserController(ILogger<UserController> logger, IUserService userService, IJwtService jwtService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost("createUser")]
    public ActionResult<Note> AddUser([FromBody] UserDto userDto)
    {
        var result = _userService.CreateUser(userDto.Username, userDto.Password);
        if (result == null)
            return BadRequest();
        return Ok(result);
    }
}