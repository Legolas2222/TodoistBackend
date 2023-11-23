using System.Security.Cryptography.X509Certificates;
using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Infrastructure.Persistence {
    class TodoRepositoryInMemory : ITodoRepository
    {
        private static List<Todo> _todos = new List<Todo>();

        public void Add(Todo todo)
        {
            _todos.Add(todo);
        }

        public Todo? GetTodoById(Guid id)
        {
            return _todos.SingleOrDefault(x => x.Id == id);
        }
    }
}