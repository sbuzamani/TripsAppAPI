using TripsApp.Domain.Models;

namespace TripsApp.ApplicationServices.Services
{
    public interface ITripService
    {
        Task<bool> SaveTrip(Trip trip);
        Task<List<Trip>> GetTrips(Guid vehicleId);
    }
}
