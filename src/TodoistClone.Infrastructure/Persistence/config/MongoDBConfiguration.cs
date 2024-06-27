using Microsoft.Extensions.Configuration;
namespace TodoistClone.Infrastructure.Persistence.config

{
    
    public class MongoDBDatabaseSettings {

        public MongoDBDatabaseSettings(IConfiguration configuration)
        {
            ConnectionString = configuration.GetSection("MongoDBConfiguration:ConnectionString").Value;
            DatabaseName = configuration.GetSection("MongoDBConfiguration:DatabaseName").Value;
            CollectionName = configuration.GetSection("MongoDBConfiguration:CollectionName").Value;
        }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; } 
        public string CollectionName { get; set; } 
    }
}