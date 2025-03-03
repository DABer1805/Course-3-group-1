using Microsoft.AspNetCore.Mvc;
using UserManagment.Models;
using UserManagment.Managers;
using UserManagment.Services;

namespace UserManagment.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("CreateUser")]
    public IActionResult CreateUser(string username, string email)
    {
        var user = new User { Username = username, Email = email };
        _userService.AddUser(user);
        return Ok($"User {username} created.");
    }

    [HttpDelete("RemoveUser")]
    public IActionResult RemoveUser(int userId)
    {
        _userService.DeleteUser(userId);
        return Ok($"User with ID {userId} removed.");
    }

    [HttpGet("ShowUser")]
    public IActionResult ShowUser(int userId)
    {
        var user = _userService.GetUser(userId);
        if (user != null)
        {
            return Ok($"User: {user.Username}, Email: {user.Email}");
        }
        else
        {
            return NotFound("User not found.");
        }
    }

    [HttpGet("ListUsers")]
    public IActionResult ListUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }
}