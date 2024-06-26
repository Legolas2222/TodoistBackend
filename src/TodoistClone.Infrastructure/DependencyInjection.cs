using Microsoft.Extensions.DependencyInjection;
using TodoistClone.Application.Common.Interfaces.Authentication;
using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Application.Common.Interfaces.Services;
using TodoistClone.Infrastructure.Authentication;
using TodoistClone.Infrastructure.Persistence;
using TodoistClone.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using TodoistClone.Infrastructure.Persistence.Config;

namespace TodoistClone.Infrastructure
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepositoryInMemory>();
            services.AddScoped<ITodoItemRepository, TodoItemRepositoryMongoDB>();
            return services;
        }

    }
}