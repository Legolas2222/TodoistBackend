using TodoistClone.Application.Services.TodoService.Commands.DTOs;
using TodoistClone.Application.Services.TodoService.Common.DTOs;

namespace TodoistClone.Application.Services.TodoService.Commands;

public interface ITodoCommandService
{
    Task<TodoItemCreateResult> Create();
    Task<TodoItemDTO> Update(TodoItemDTO newTodo);
    Task<TodoItemDeleteResult> Delete(Guid id);
}