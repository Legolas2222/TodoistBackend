using TodoistClone.Application.Services.TodoService;

namespace TodoistClone.Application.Services.TodoService
{
    public interface ITodoService
    {
        TodoGetResult GetById(Guid id);
    }

}

