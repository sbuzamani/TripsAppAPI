using MongoDB.Driver;

namespace TripsApp.Mongo.Repositories
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoClient _client;

        public readonly IMongoDatabase database;
        public MongoContext(string connectionString, string databaseName)
        {
            _client = new MongoClient(connectionString);
            database = _client.GetDatabase(databaseName);
        }

        public IMongoDatabase GetDatabase()
        {
            return database;
        }
    }
}
