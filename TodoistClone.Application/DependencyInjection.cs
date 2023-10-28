using Microsoft.Extensions.DependencyInjection;
using TodoistClone.Application.Services.Authentication;
using TodoistClone.Application.Services.TodoService;

namespace TodoistClone.Application
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITodoService, TodoService>();
            return services;
        }

    }
}
