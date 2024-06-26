namespace TodoistClone.Infrastructure.Persistence.Config
{
    public class MongoDBDatabaseSettings
    {

        public MongoDBDatabaseSettings(string connectionString, string collectionName, string databaseName)
        {
            this.ConnectionString = connectionString;
            this.CollectionName = collectionName;
            this.DatabaseName = databaseName;
        }
        public string ConnectionString { get; init; }
        public string DatabaseName { get; init; } 
        public string CollectionName { get; init; } 
    }
}