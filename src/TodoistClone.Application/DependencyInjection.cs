using Microsoft.Extensions.DependencyInjection;
using TodoistClone.Application.Services.Authentication.Commands;
using TodoistClone.Application.Services.Authentication.Queries;
using TodoistClone.Application.Services.TodoService.Commands;
using TodoistClone.Application.Services.TodoService.Queries;

namespace TodoistClone.Application;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        services.AddScoped<ITodoCommandService, TodoCommandService>();
        services.AddScoped<ITodoQueryService, TodoQueryService>();
        return services;
    }

}
