using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Vidly.IBusinessLogic;
using Vidly.Models.In;

namespace Vidly.WebApi.Controllers;

[ApiController]
[Route("api/login")]
public class LoginController:ControllerBase
{
    private ISessionService _sessionService;

    public LoginController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginDto login)
    {
        try
        {
            var token = _sessionService.Login(login.Email, login.Password);
            return Ok(new { token = token });
        }
        catch (InvalidCredentialException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}