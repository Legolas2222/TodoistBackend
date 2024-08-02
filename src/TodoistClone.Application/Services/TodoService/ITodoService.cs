namespace TodoistClone.Application.Services.TodoService
{
    public interface ITodoService
    {
        TodoGetResult GetById(Guid id);
        TodoPostResult Add(string title, string description, bool done);
    }

}

