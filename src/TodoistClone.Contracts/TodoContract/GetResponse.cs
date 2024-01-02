namespace TodoistClone.Contracts.TodoContract
{
    public record TodoGetResponse(
        Guid Id,
        string Title,
        string Description,
        bool Done
    );
}