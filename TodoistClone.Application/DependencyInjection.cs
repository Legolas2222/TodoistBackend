using Microsoft.Extensions.DependencyInjection;
using TodoistClone.Application.Services.Authentication.Commands;
using TodoistClone.Application.Services.Authentication.Queries;
using TodoistClone.Application.Services.TodoService;

namespace TodoistClone.Application;


public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        services.AddScoped<ITodoService, TodoService>();
        return services;
    }

}
