using TodoistClone.Domain.Entities;

namespace TodoistClone.Application.Common.Interfaces.Persistence
{
    public interface ITodoRepository
    {
        TodoItem? GetTodoById(Guid id);

        void Add(TodoItem todo);
    }
}