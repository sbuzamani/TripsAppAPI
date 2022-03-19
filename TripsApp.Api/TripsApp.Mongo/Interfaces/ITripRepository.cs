using TripsApp.Mongo.Entities;

namespace TripsApp.Mongo.Interfaces
{
    public interface ITripRepository : IRepository<Trip>
    {
        Task<List<Trip>> GetVehicleTripsAsync(Guid vehicleId, DateTime startDate, DateTime endDate);
    }
}
