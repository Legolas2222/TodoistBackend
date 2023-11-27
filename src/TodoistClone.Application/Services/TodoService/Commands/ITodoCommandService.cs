using TodoistClone.Application.Services.TodoService.Commands.DTOs;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Delete;
using TodoistClone.Application.Services.TodoService.Common.DTOs;

namespace TodoistClone.Application.Services.TodoService.Commands;

public interface ITodoCommandService
{
    Task<TodoItemCreateResult> Create(TodoItemCreateRequest request);
    Task<TodoItemDTO> Update(TodoItemDTO newTodo);
    Task<TodoItemDeleteResult> Delete(TodoItemDeleteRequest request);
}