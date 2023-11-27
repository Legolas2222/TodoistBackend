using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Application.Services.TodoService.Common.DTOs;

namespace TodoistClone.Application.Services.TodoService.Queries;

public class TodoQueryService : ITodoQueryService
{
    private readonly ITodoItemRepository _todoItemRepository;
    public TodoQueryService(ITodoItemRepository todoItemRepository)
    {
        this._todoItemRepository = todoItemRepository;        
    }


    public async Task<IEnumerable<TodoItemDTO>> GetAll()
    {
        //! Validation
        var result = await _todoItemRepository.GetAll(); 

        var respone = new List<TodoItemDTO>();
        foreach (var item in result) {
            respone.Add(new TodoItemDTO(
                item.Id,
                item.Title,
                item.Description,
                item.Done));
        }
        return (IEnumerable<TodoItemDTO>)result;
    }

    public async Task<TodoItemDTO> GetById(Guid id)
    {
        //! Validation
        var result = await _todoItemRepository.GetById(id);
        var respone = new TodoItemDTO(
            result.Id,
            result.Title,
            result.Description,
            result.Done);
        return respone;
    }
}