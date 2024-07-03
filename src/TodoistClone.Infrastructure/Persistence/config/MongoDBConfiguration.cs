using Microsoft.Extensions.Configuration;
namespace TodoistClone.Infrastructure.Persistence.config

{
    
    public class MongoDBDatabaseSettings {

        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; } 
        public string? CollectionName { get; set; } 
    }
}