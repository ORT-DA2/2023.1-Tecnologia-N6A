using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Vidly.Models.Out;

namespace Vidly.WebApi.filters;

public class ExceptionFilter:Attribute,IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        List<Type> errors404 = new List<Type>()
        {
            typeof(KeyNotFoundException)
        };
        List<Type> errors401 = new List<Type>()
        {
            typeof(InvalidCredentialException)
        };
        //409 422
        ErrorDto response = new ErrorDto()
        {
            ErrorMessage = context.Exception.Message
        };
        Type errorType = context.Exception.GetType();
        if (errors401.Contains(errorType))
        {
            response.Code = 401;
        }
        else if (errors404.Contains(errorType))
        {
            response.Code = 404;
        }
        else
        {
            response.Code = 500;
            Console.Write(context.Exception);
        }

        context.Result = new ObjectResult(response)
        {
            StatusCode = response.Code
        };
    }
}