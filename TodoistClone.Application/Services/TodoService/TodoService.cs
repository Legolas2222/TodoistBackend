
using TodoistClone.Application.Common.Interfaces.Persistence;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Application.Services.TodoService {
    class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public TodoPostResult Add(string title, string description, bool done) {
            // Create todo and generate id from arguments
            var todo = new Todo {
                Title = title,
                Description = description,
                Done = done,
                Id = Guid.NewGuid()
            };
            // Persist the newly created Todo
            _todoRepository.Add(todo);

            // Return the id of the newly created todo object
            return new TodoPostResult(todo.Id);
        }

        public TodoGetResult GetById(Guid id)
        {
            if (_todoRepository.GetTodoById(id) is not Todo todo)
            {
                throw new Exception("Todo with given id does not exist");
            }
            return new TodoGetResult(todo);
        }
    }
}