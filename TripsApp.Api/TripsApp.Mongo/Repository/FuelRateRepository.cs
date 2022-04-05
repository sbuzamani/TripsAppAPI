using MongoDB.Driver;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repository
{
    public class FuelRateRepository : Repository<FuelRate>, IFuelRateRepository
    {
        public FuelRateRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }

        public async Task<double> GetAsync()
        {
            var collection = GetCollection();

            var filter = Builders<FuelRate>.Filter.Exists("Rate");

            var result = await collection.FindAsync(filter);

            return result.First().Rate;
        }
    }
}
