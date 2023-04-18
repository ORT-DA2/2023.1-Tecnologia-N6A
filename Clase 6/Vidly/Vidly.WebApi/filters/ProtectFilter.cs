using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Vidly.BusinessLogic;
using Vidly.Domain.Entities;
using Vidly.IBusinessLogic;
using Vidly.Models.Out;

namespace Vidly.WebApi.filters;

public class ProtectFilter:Attribute, IActionFilter
{
    private ISessionService? sesionService;
    private RoleType _role;

    public ProtectFilter(RoleType role)
    {
        _role = role;
    }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        this.sesionService = context.HttpContext.RequestServices.GetService<ISessionService>();
        StringValues token;
        context.HttpContext.Request.Headers.TryGetValue("Authentication", out token);
        ErrorDto error = new ErrorDto()
        {
            ErrorMessage = "User not allowed tod o this action",
            Code = 401
        };
        try
        {
            Guid guidToken = new Guid(token);
            User user = this.sesionService.GetLoggedUser(guidToken);
            if (user != null && user.Role != _role)
            {
                context.Result = new ObjectResult(error)
                {
                    StatusCode = error.Code
                };
            }
        }
        catch (KeyNotFoundException)
        {
            context.Result = new ObjectResult(error)
            {
                StatusCode = error.Code
            };
        }

    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
       
    }
}