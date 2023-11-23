using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TodoistClone.Api.Middleware;

public class ErrorHandlingMiddlware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddlware(RequestDelegate next) {
        _next = next;
    }

    public async Task Invoke(HttpContext context) {
        try {
            await _next(context);
        }
        catch (Exception exception) {
            await HandleExceptionAsync(context, exception);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception) {
        var code = HttpStatusCode.InternalServerError;
        var result = JsonSerializer.Serialize(new { error = "An error occured while processing your request." });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}

