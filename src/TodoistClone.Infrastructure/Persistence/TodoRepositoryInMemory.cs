using System.Security.Cryptography.X509Certificates;
using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Infrastructure.Persistence
{
    class TodoRepositoryInMemory : ITodoRepository
    {
        private static List<TodoItem> _todos = new List<TodoItem>();

        public void Add(TodoItem todo)
        {
            _todos.Add(todo);
        }

        public TodoItem? GetTodoById(Guid id)
        {
            return _todos.SingleOrDefault(x => x.Id == id);
        }
    }
}