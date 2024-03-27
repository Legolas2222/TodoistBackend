using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Infrastructure.Persistence;

public class TodoItemRepositoryInMemory : ITodoItemRepository
{
    private List<TodoItem> todos = new();
    public Task<Guid> Create()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItem>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<TodoItem> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<TodoItem> Update(TodoItem item)
    {
        throw new NotImplementedException();
    }
}