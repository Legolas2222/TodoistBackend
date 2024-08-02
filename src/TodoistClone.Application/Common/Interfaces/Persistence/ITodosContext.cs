using MongoDB.Driver;
using TodoistClone.Domain.Entities; 
namespace TodoistClone.Infrastructure.Persistence.config
{
    public interface ITodosContext
    {
        IMongoCollection<TodoItem> TodoItems { get; }
    }
}