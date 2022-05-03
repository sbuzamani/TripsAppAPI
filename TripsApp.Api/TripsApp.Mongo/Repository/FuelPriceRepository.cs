using MongoDB.Driver;
using System.Linq.Expressions;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repository
{
    public class FuelPriceRepository : Repository<FuelPrice>, IFuelPriceRepository
    {
        public FuelPriceRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }

        public override async Task<FuelPrice> GetAsync(Expression<Func<FuelPrice, bool>> field, Guid countryId)
        {
            var collection = GetCollection();

            var filter = Builders<FuelPrice>.Filter.Eq(field => field.CountryId, countryId);

            var result = await collection.FindAsync(filter);

            return result.FirstOrDefault();
        }
    }
}
