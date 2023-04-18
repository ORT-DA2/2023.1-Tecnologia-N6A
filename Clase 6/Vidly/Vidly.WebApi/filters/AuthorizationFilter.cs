using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Vidly.IBusinessLogic;
using Vidly.Models.Out;

namespace Vidly.WebApi.filters;

public class AuthorizationFilter: Attribute, IAuthorizationFilter
{
    private ISessionService? sessionService;

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        this.sessionService = context.HttpContext.RequestServices.GetService<ISessionService>();
        ErrorDto errorDto = new ErrorDto()
        {
            ErrorMessage = "USer not allowed to do this action",
            Code = 401
        };

        StringValues token;
        context.HttpContext.Request.Headers.TryGetValue("Authentication", out token);
        if (token.Count == 0 || token == "")
        {
            context.Result = new ObjectResult(errorDto)
            {
                StatusCode = errorDto.Code
            };
        }
        else
        {
            try
            {
                Guid guidToken = new Guid(token);
                sessionService.GetLoggedUser(guidToken);
            }
            catch (KeyNotFoundException ex)
            {
                errorDto.ErrorMessage = ex.Message;
                context.Result = new ObjectResult(errorDto)
                {
                    StatusCode = errorDto.Code
                };
            }
        }
    }
    
}