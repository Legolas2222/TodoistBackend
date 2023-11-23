using TodoistClone.Domain.Entities;

namespace TodoistClone.Application.Services.Authentication
{
    public record AuthenticationResult(
        User user,
        string Token);
}
