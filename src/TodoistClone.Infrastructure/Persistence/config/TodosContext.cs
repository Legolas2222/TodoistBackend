using MongoDB.Driver;
using TodoistClone.Domain.Entities;
using Microsoft.Extensions.Options;

namespace TodoistClone.Infrastructure.Persistence.config
{
    public class TodosContext : ITodosContext
    {
        // public TodosContext(string ConnectionString, string DatabaseName, string CollectionName)
        // {
        //     var client = new MongoClient(ConnectionString);
        //     var database = client.GetDatabase(DatabaseName);

            
        //     TodoItems = database.GetCollection<TodoItem>(CollectionName);
        //     Console.WriteLine("Connected to MongoDB");
        //     Console.WriteLine("Database: " + DatabaseName);
        //     Console.WriteLine("Collection: " + CollectionName);
        //     Console.WriteLine("Connection String: " + ConnectionString);
        // }
        private readonly IOptions<MongoDbConfiguration> _options;

        public TodosContext(IOptions<MongoDbConfiguration> options) {
            this._options = options;
            var client = new MongoClient(this._options.Value.ConnectionString);
            var database = client.GetDatabase(this._options.Value.DatabaseName);

            
            TodoItems = database.GetCollection<TodoItem>(this._options.Value.CollectionName);
            Console.WriteLine("Connected to MongoDB");
            Console.WriteLine("Database: " + this._options.Value.DatabaseName);
            Console.WriteLine("Collection: " + this._options.Value.CollectionName);
            Console.WriteLine("Connection String: " + this._options.Value.ConnectionString);
        }
           
        public IMongoCollection<TodoItem> TodoItems { get; }

    }
}