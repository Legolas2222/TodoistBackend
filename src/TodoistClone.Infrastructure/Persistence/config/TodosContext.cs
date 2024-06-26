using MongoDB.Driver;
using TodoistClone.Domain.Entities;

namespace TodoistClone.Infrastructure.Persistence.config
{
    public class TodosContext : ITodosContext
    {
        public TodosContext(string ConnectionString, string DatabaseName, string CollectionName)
        {
            var client = new MongoClient(ConnectionString);
            var database = client.GetDatabase(DatabaseName);

            TodoItems = database.GetCollection<TodoItem>(CollectionName);
            Console.WriteLine("Connected to MongoDB");
            Console.WriteLine("Database: " + DatabaseName);
            Console.WriteLine("Collection: " + CollectionName);
            Console.WriteLine("Connection String: " + ConnectionString);
        }
           
        public IMongoCollection<TodoItem> TodoItems { get; }

    }
}