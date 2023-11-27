using System.ComponentModel;
using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Application.Services.TodoService.Commands.DTOs;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Delete;
using TodoistClone.Application.Services.TodoService.Common.DTOs;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Application.Services.TodoService.Commands;

public class TodoCommandService : ITodoCommandService
{
    private readonly ITodoItemRepository _todoitemrepository;

    public TodoCommandService(ITodoItemRepository todoitemrepository)
    {
        _todoitemrepository = todoitemrepository;
    }

    public async Task<TodoItemCreateResult> Create(TodoItemCreateRequest request)
    {
        //!Validation 
        Guid id = await _todoitemrepository.Create();
        
        var respone = new TodoItemCreateResult(id);
        return respone;
    }

    public async Task<TodoItemDeleteResult> Delete(TodoItemDeleteRequest request)
    {
        //!Validation 
        bool result = await _todoitemrepository.Delete(request.Id);

        var respone = new TodoItemDeleteResult(result);
        return respone;
    }

    public async Task<TodoItemDTO> Update(TodoItemDTO newTodo)
    {
        //!Validation

        TodoItem result = await _todoitemrepository.Update(new TodoItem() {
            Id = newTodo.Id,
            Title = newTodo.Title,
            Description = newTodo.Description,
            Done = newTodo.Done
        }); 

        var respone = new TodoItemDTO(result.Id, result.Title, result.Description, result.Done);

        return respone;
        
    }   
}