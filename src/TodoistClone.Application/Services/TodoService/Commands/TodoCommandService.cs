using System.ComponentModel;
using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Create;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Delete;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Update;
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

    public async Task<TodoItemCreateResult> Add(TodoItemCreateRequest request)
    {
        //!Validation 
        var todoItem = new TodoItem() {
            Id = new Guid(),
            Title = request.Title,
            Description = request.Description,
            Done = request.Done
        };

        Guid id = await _todoitemrepository.Add(todoItem);

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

    public async Task<TodoItemUpdateResult> Update(TodoItemDTO data)
    {
        //!Validation

        var helperItem = new TodoItem()
        {
            Id = data.Id,
            Title = data.Title,
            Description = data.Description,
            Done = data.Done
        };
        Guid id = await _todoitemrepository.Update(data.Id, helperItem);

        var respone = new TodoItemUpdateResult(id);

        return respone;

    }
}