using EfSait.Entity.UserActivity;
using EfSait.Service.ModelsRequest.UserActivity;
using EfSait.Service.Services.Interface.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EfSait.API.Controllers;


public class UserController : ApiBaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost(Name = "CreateUser")]
    public async Task<IActionResult> CreateAsync(UserRequest user)
    {
        ArgumentNullException.ThrowIfNull(user);
        await _userService.CreateAsync(user, new CancellationToken());
        return Ok();
    }
    [HttpGet(Name = "GetAllUser")]
    public async Task<List<User>> GetAll()
    {
        var users = await _userService.GetAllAsync(new CancellationToken());
        return users;
    }
    [HttpPost("Login")]
    public async Task<Token> Login(string surname, string name, string patronymic)
    {
        return await _userService.LoginAsync(surname, name, patronymic,new CancellationToken());
    }
    [Authorize]
    [HttpGet("Check")]
    public string Check()
    {
        return "Работает";
    }
}