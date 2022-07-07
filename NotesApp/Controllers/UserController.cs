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

    public UserController(IUserService userService, IJwtService jwtService, ILogger<UserController> logger)
    {
        _userService = userService;
        _jwtService = jwtService;
        _logger = logger;
    }

    [HttpPost("createUser")]
    public ActionResult<User> AddUser([FromBody] UserDto userDto)
    {
        var usernameTaken = _userService.GetUser(userDto.Username) == null ? false : true;
        if (usernameTaken)
            return BadRequest($"This username is taken, please try another");
        var result = _userService.CreateUser(userDto.Username, userDto.Password);
        if (result == null)
            return BadRequest();
        return Ok(result);
    }

    [HttpPost("login")]
    public ActionResult<string> Login(UserDto request)
    {
        if (!_userService.Login(request.Username, request.Password))
            return BadRequest($"Incorrect credentials");
        string token = _jwtService.GetJwtToken(request.Username);
        return Ok(token);
    }
}