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

        public override async Task<IEnumerable<Trip>> ListAsync(Guid vehicleId, DateTime startDate, DateTime endDate)
        {
            var collection = GetCollection();
            var filter = Builders<Trip>.Filter.Eq("VehicleId", vehicleId) &
            Builders<Trip>.Filter.Gte(x => x.TimeStamp, startDate) & Builders<Trip>.Filter.Lte(x => x.TimeStamp, endDate);

            var result = await collection.Find(filter).ToListAsync();

            return result;
        }
    }
}
