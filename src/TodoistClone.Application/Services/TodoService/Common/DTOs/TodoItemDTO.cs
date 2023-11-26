namespace TodoistClone.Application.Services.TodoService.Common.DTOs;

public record TodoItemDTO (
    Guid Id,
    string Title,
    string Description,
    bool Done
);