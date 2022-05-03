using MongoDB.Driver;
using System.Linq.Expressions;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repository
{
    public class ExchangeRateRepository : Repository<ExchangeRate>, IExchangeRateRepository
    {
        public ExchangeRateRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }

        public override async Task<ExchangeRate> GetAsync(Expression<Func<ExchangeRate, bool>> field, Guid countryId)
        {
            var collection = GetCollection();

            var filter = Builders<ExchangeRate>.Filter.Eq(field => field.CountryId, countryId);

            var result = await collection.FindAsync(filter);

            return result.FirstOrDefault();
        }
    }
}
