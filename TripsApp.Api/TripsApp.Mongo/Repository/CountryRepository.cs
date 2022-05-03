using MongoDB.Driver;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }

        public override async Task<Country> GetAsync(Guid countryId)
        {
            var collection = GetCollection();

            var filter = Builders<Country>.Filter.Eq(x => x.Id, countryId);

            var result = await collection.FindAsync(filter);

            return result.FirstOrDefault();
        }
    }
}
