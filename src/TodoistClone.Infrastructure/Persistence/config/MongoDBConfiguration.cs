using Microsoft.Extensions.Configuration;
namespace TodoistClone.Infrastructure.Persistence.config
{
    public class MongoDbConfiguration
    {
        public MongoDbConfiguration() 
        {
            if (ConnectionString == null || DatabaseName == null || CollectionName == null)
            {
                throw new Exception("Empty MongoDBConfiguration");
                
            }
            Console.WriteLine(ConnectionString);
        }
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? CollectionName { get; set; }

    }
}