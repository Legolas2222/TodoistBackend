namespace TodoistClone.Application.Services.TodoService.Commands.DTOs;

public record TodoItemCreateRequest(
    string Title,
    string Description,
    bool Done);