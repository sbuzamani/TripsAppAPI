using MongoDB.Driver;

namespace TripsApp.Mongo.Interfaces
{
    public interface IMongoContext
    {
        IMongoDatabase GetDatabase();

        IMongoCollection<T> GetCollection<T>();

        void DropDatabase(string databaseName);
    }
}