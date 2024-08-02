using TodoistClone.Domain.Entities;

namespace TodoistClone.Application.Common.Interfaces.Persistence;

public interface ITodoItemRepository : IBaseRepository<TodoItem>
{
    public Task<TodoItem?> GetByIdAsync(Guid id);
    public Task<List<TodoItem>> GetAllAsync();
}