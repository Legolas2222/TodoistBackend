namespace TodoistClone.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        string Firstname,
        string Lastname,
        string Email,
        string Token);
}
