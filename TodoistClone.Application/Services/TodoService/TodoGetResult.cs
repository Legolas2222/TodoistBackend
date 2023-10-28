using TodoistClone.Domain.Entities;

namespace TodoistClone.Application.Services.TodoService {
    public record TodoGetResult(
        Todo Todo
    );
}