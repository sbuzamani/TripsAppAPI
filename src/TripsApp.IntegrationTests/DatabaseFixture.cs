using TripsApp.Mongo.Interfaces;
using TripsApp.Mongo.Repositories;

namespace TripsApp.IntegrationTests
{
    public class DatabaseFixture<T> : IDisposable where T : class
    {
        public readonly IMongoContext context;
        private static string _entityName;

        public DatabaseFixture()
        {
            _entityName = typeof(T).Name;
            var _fullPath = $"D:\\Workspace\\TripsApp\\src\\TripsApp.IntegrationTests\\Data\\{_entityName}-collection.json";
            var fileName = File.ReadAllText(_fullPath);
            context = new MongoContext("mongodb://localhost:27017", "Integration_Tests");
            var document = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<IEnumerable<T>>(fileName);
            var collection = context.GetCollection<T>();
            collection.Database.DropCollection(_entityName);
            collection.InsertMany(document);
        }

        public void Dispose()
        {
            context.DropDatabase(_entityName);
        }
    }
}
