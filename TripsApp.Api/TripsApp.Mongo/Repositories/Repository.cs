using MongoDB.Driver;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IMongoContext _mongoContext;
        public Repository(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var collection = GetCollection();

            var filter = Builders<T>.Filter.Eq(x => x.Id, id);

            await collection.DeleteOneAsync(filter);//actions and 

            return true;
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            var collection = GetCollection();

            var filter = Builders<T>.Filter.Eq(x => x.Id, id);

            var result = await collection.FindAsync(filter);

            return result.First();//private function 
        }

        public async Task<bool> SaveAsync(T t)
        {
            var collection = GetCollection();

            await collection.InsertOneAsync(t);

            return true;
        }

        public async Task<bool> UpdateAsync(T t)
        {
            var collection = GetCollection();

            var filter = Builders<T>.Filter.Eq(x => x.Id, t.Id);

            var result = await collection.ReplaceOneAsync(filter, t);

            return true;
        }

        public virtual async Task<T> GetByCountryIdAsync(Guid countryId)
        {
            var collection = GetCollection();

            var filter = Builders<T>.Filter.Eq("CountryId", countryId);

            var result = await collection.FindAsync(filter);

            return result.First();
        }

        protected IMongoCollection<T> GetCollection()
        {
            var collectionName = GetCollectionName();

            return _mongoContext.GetDatabase().GetCollection<T>(collectionName);
        }

        private string GetCollectionName()
        {
            return typeof(T).Name;
        }
    }
}
