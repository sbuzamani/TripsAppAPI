using TripsApp.Mongo.Entities;

namespace TripsApp.Mongo.Interfaces
{
    public interface ITripRepository : IRepository<Trip>
    {
        Task<TripAggregation> GetTripAggregationAsync(Guid vehicleId, DateTime startDate, DateTime endDate);
    }
}
