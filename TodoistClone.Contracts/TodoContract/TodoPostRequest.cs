namespace TodoistClone.Contracts.TodoContract {
    public record TodoPostRequest(
        string Title,
        string Description,
        bool Done
    );
}