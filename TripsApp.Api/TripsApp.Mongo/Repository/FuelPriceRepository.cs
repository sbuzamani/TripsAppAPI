using MongoDB.Driver;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repository
{
    public class FuelPriceRepository : Repository<FuelPrice>, IFuelPriceRepository
    {
        public FuelPriceRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }

        public async Task<FuelPrice> GetFuelPriceAsync(int countryId)
        {
            var collection = GetCollection();

            var filter = Builders<FuelPrice>.Filter.Eq("CountryId", countryId);

            var result = await collection.FindAsync(filter);

            return result.FirstOrDefault();
        }
    }
}
