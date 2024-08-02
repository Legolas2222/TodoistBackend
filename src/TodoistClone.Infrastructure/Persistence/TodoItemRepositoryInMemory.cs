using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Infrastructure.Persistence;

public class TodoItemRepositoryInMemory : ITodoItemRepository
{
    private static List<TodoItem> todos = [];
    public Task<TodoItem?> GetByIdAsync(Guid id)
    {
        var item = todos.Find(x => x._Id == id);
        return Task.FromResult(item);
    }
    public Task<List<TodoItem>> GetAllAsync()
    {
        return Task.FromResult(todos);
    }

    public void Add(TodoItem item)
    {
        todos.Add(item);
    }

    public void Update(TodoItem item)
    {
        var oldItem = todos.Find(x => x._Id == item._Id);
        if (oldItem is not null)
        {
            todos.Remove(oldItem);
            todos.Add(item);
        }
        if (oldItem is null)
        {
            throw new Exception("Provided ID did not match a db entry");
        }

    }
    public void Delete(TodoItem item)
    {
        todos.Remove(item);

    }


}