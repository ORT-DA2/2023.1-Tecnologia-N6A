using IBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Vidly.Domain.Entities;

namespace Vidly.WebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController: ControllerBase
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult Add([FromBody] User user)
    {
        _userService.AddUser(user);
        return Ok(user);
    }
}