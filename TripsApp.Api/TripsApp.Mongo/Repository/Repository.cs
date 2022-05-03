using MongoDB.Driver;
using System.Linq.Expressions;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IMongoClient _client;

        private readonly IMongoDatabase _database;
        public Repository(string connectionString, string databaseName)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(databaseName);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var collection = GetCollection();

            var filter = Builders<T>.Filter.Eq("_id", id);

            await collection.DeleteOneAsync(filter);

            return true;
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> field, Guid id)
        {
            var collection = GetCollection();

            var filter = Builders<T>.Filter.Eq(field => field.Id, id);

            var result = await collection.FindAsync(filter);

            return result.First();
        }

        public virtual async Task<IEnumerable<T>> ListAsync(Guid id, DateTime startDate, DateTime endDate)
        {
            var collection = GetCollection();

            var filter = Builders<T>.Filter.Eq("_id", id);

            var result = await collection.FindAsync(filter);

            return result.ToList();
        }

        public async Task<bool> SaveAsync(T t)
        {
            var collection = GetCollection();
            try
            {
                await collection.InsertOneAsync(t);

            }
            catch (Exception e)
            {

                throw;
            }

            return true;
        }

        public async Task<bool> UpdateAsync(T t)
        {
            var collection = GetCollection();

            var filter = Builders<T>.Filter.Eq("_id", t.Id);

            var result = await collection.ReplaceOneAsync(filter, t);

            return true;
        }

        protected IMongoCollection<T> GetCollection()
        {
            var collectionName = GetCollectionName();

            return _database.GetCollection<T>(collectionName);
        }

        private string GetCollectionName()
        {
            return typeof(T).Name;
        }
    }
}
