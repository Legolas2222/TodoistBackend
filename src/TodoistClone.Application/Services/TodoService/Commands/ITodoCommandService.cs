using TodoistClone.Application.Services.TodoService.Commands.DTOs.Create;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Delete;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Update;

namespace TodoistClone.Application.Services.TodoService.Commands;

public interface ITodoCommandService
{
    Task Add(TodoItemCreateRequest request);
    Task Update(TodoItemUpdateRequest newTodo);
    Task Delete(TodoItemDeleteRequest request);
}