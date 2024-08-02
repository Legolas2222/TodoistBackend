using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Create;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Delete;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Update;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Application.Services.TodoService.Commands;

public class TodoCommandService(ITodoItemRepository todoitemrepository) : ITodoCommandService
{
    private readonly ITodoItemRepository _todoitemrepository = todoitemrepository;

    public Task Add(TodoItemCreateRequest request)
    {
        //!Validation 
        var todoItem = new TodoItem(
            request.Title,
            request.Description,
            request.Done
        );

        _todoitemrepository.Add(todoItem);
        return Task.CompletedTask;
    }

    public Task Delete(TodoItemDeleteRequest request)
    {
        //!Validation 
        var item = _todoitemrepository.GetByIdAsync(request.Id);
        if (item.Result is null)
        {
            throw new Exception("Provided ID did not match a db entry");
        }
        _todoitemrepository.Delete(item.Result);
        return Task.CompletedTask;

    }

    public Task Update(TodoItemUpdateRequest data)
    {
        //!Validation
        var item = _todoitemrepository.GetByIdAsync(data.Id);
        if (item.Result is null)
        {
            throw new Exception("Provided ID did not match a db entry");
        }
        _todoitemrepository.Delete(item.Result);
        return Task.CompletedTask;
    }
}