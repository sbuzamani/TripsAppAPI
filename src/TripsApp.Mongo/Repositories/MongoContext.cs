using MongoDB.Driver;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repositories
{
    public class MongoContext : IMongoContext
    {
        private IMongoClient _client;
        public IMongoDatabase database;

        public MongoContext(string connectionString, string databaseName)
        {
            _client = new MongoClient(connectionString);
            database = _client.GetDatabase(databaseName);
        }

        public IMongoDatabase GetDatabase()
        {
            return database;
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            var collectionName = typeof(T).Name;

            return database.GetCollection<T>(collectionName);
        }

        public void DropDatabase(string databaseName)
        {
            _client.DropDatabase(databaseName);
        }
    }
}
