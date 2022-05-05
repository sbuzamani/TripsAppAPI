using MongoDB.Driver;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repository
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }

        public async Task<TripAggregation> GetTripAggregationAsync(Guid vehicleId, DateTime startDate, DateTime endDate)
        {
            var collection = GetCollection();
            var vehicleFilter = Builders<Trip>.Filter.Eq(x => x.VehicleId, vehicleId);
            var dateFilter = Builders<Trip>.Filter.Gte(x => x.TimeStamp, startDate) & Builders<Trip>.Filter.Lte(x => x.TimeStamp, endDate);

            var aggregationResult = collection.Aggregate().Match(vehicleFilter).Match(dateFilter)
            .Group(a => new { a.VehicleId, a.CountryId }, r => new TripAggregation
            { VehicleId = r.First().VehicleId, CountryId = r.First().CountryId, TotalDistance = r.Sum(b => b.Distance) })
            .FirstOrDefaultAsync();

            var result = await aggregationResult;

            return result;
        }
    }
}
