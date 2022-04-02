using TripsApp.Mongo.Entities;

namespace TripsApp.Mongo.Interfaces
{
    public interface ITripRepository : IRepository<Trip>
    {
        Task<IEnumerable<Trip>> ListAsync(Guid vehicleId, DateTime startDate, DateTime endDate);
    }
}
