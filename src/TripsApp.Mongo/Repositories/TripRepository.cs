using MongoDB.Driver;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repositories
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(IMongoContext mongoContext) : base(mongoContext)
        {
        }

        public async Task<TripAggregation> GetTripAggregationAsync(Guid vehicleId, DateTime startDate, DateTime endDate)
        {
            var vehicleFilter = Builders<Trip>.Filter.Eq(x => x.VehicleId, vehicleId);
            var dateFilter = Builders<Trip>.Filter.Gte(x => x.TimeStamp, startDate) & Builders<Trip>.Filter.Lte(x => x.TimeStamp, endDate);

            var aggregationResult = _collection.Aggregate().Match(vehicleFilter).Match(dateFilter)
            .Group(a => new { a.VehicleId, a.CountryId }, r => new TripAggregation
            { VehicleId = r.First().VehicleId, CountryId = r.First().CountryId, TotalDistance = r.Sum(b => b.Distance) })
            .FirstOrDefaultAsync();

            var result = await aggregationResult;
            return result;
        }
    }
}
