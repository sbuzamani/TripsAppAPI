using MongoDB.Driver;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repositories
{
    public class FuelPriceRepository : Repository<FuelPrice>, IFuelPriceRepository
    {
        public FuelPriceRepository(IMongoContext mongoContext) : base(mongoContext)
        {
        }
        public async Task<FuelPrice> GetByCountryIdAsync(Guid countryId)
        {
            var filter = Builders<FuelPrice>.Filter.Eq(x => x.CountryId, countryId);

            var result = await _collection.FindAsync(filter);

            return result.First();
        }
    }
}
