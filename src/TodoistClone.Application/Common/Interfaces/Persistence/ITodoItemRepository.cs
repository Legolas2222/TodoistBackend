using TodoistClone.Domain.Entities;

namespace TodoistClone.Application.Common.Interfaces.Persistence;

public interface ITodoItemRepository
{
    public Task<TodoItem> GetById(Guid id);
    public Task<IEnumerable<TodoItem>> GetAll();
    public Task<Guid> Create();
    public Task<TodoItem> Update(TodoItem item);
    public Task<bool> Delete(Guid id); 

}