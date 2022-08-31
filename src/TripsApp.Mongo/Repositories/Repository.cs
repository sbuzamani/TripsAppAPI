using MongoDB.Driver;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly IMongoContext _mongoContext;
        protected IMongoCollection<T> _collection;
        public Repository(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
            _collection = _mongoContext.GetCollection<T>();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, id);

            await _collection.DeleteOneAsync(filter);

            return true;
        }

        public virtual async Task<T> GetAsync(Guid id)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, id);

            var result = await _collection.FindAsync(filter);

            return result.First();
        }

        public async Task<bool> SaveAsync(T t)
        {
            await _collection.InsertOneAsync(t);

            return true;
        }

        public async Task<bool> UpdateAsync(T t)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, t.Id);

            var result = await _collection.ReplaceOneAsync(filter, t);

            return true;
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            var filter = Builders<T>.Filter.Empty;

            var result = await _collection.FindAsync(filter);

            return result.ToList();
        }
    }
}
