using TodoistClone.Application.Services.TodoService.Common.DTOs;

namespace TodoistClone.Application.Services.TodoService.Queries;

public interface ITodoQueryService
{
    Task<TodoItemDTO> GetById(Guid id);
    Task<IEnumerable<TodoItemDTO>> GetAll();
}