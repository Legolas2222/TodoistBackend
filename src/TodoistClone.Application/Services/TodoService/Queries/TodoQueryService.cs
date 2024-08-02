using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Application.Services.TodoService.Common.DTOs;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Application.Services.TodoService.Queries;

public class TodoQueryService : ITodoQueryService
{
    private readonly ITodoItemRepository _todoItemRepository;
    public TodoQueryService(ITodoItemRepository todoItemRepository)
    {
        this._todoItemRepository = todoItemRepository;
    }


    public async Task<List<TodoItemDTO>> GetAll()
    {
        //! Validation
        var result = await _todoItemRepository.GetAllAsync();

        var response = new List<TodoItemDTO>();
        foreach (var item in result)
        {
            response.Add(new TodoItemDTO(
                item._Id,
                item.Title,
                item.Description,
                item.Done));
        }

        return response;
    }

    public async Task<TodoItemDTO> GetById(Guid id)
    {
        //! Validation
        TodoItem? result = await _todoItemRepository.GetByIdAsync(id);

        if (result is not null)
        {
            var respone = new TodoItemDTO(
            result._Id,
            result.Title,
            result.Description,
            result.Done);
            return respone;
        }
        throw new Exception($"The Todoitem with id {id} could not be found");

    }
}