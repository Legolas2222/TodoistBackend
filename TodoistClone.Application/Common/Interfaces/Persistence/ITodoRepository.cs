using TodoistClone.Domain.Entities;

namespace TodoistClone.Application.Common.Interfaces.Persistence {
    public interface ITodoRepository {
        Todo? GetTodoById(Guid id);

        void Add(Todo todo);
    }
}