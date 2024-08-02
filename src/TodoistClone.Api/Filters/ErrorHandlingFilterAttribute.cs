using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace TodoistClone.Api.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Title = "An error occured while processing your request (ErrorHandlingFilterAttributes)",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Instance = context.HttpContext.Request.Path,
            Status = (int)HttpStatusCode.InternalServerError,
            Detail = exception.Message
        };
        context.Result = new ObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}