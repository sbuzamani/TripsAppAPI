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

        public async Task<List<Trip>> GetVehicleTripsAsync(Guid vehicleId, DateTime startDate, DateTime endDate)
        {
            var collection = GetCollection();

            var filter = Builders<Trip>.Filter.Eq("_id", vehicleId) &
                Builders<Trip>.Filter.Gte(x => x.TimeStamp, startDate) &
                Builders<Trip>.Filter.Lte(x => x.TimeStamp, startDate);

            var result = await collection.FindAsync(filter);

            return result.ToList();
        }
    }
}
