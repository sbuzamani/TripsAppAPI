using MongoDB.Driver;

namespace TripsApp.Mongo.Repositories
{
    public interface IMongoContext
    {
        IMongoDatabase GetDatabase();
    }
}