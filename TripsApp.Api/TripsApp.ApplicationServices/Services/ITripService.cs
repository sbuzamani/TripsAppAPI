using TripsApp.Domain.Models;

namespace TripsApp.ApplicationServices.Services
{
    public interface ITripService
    {
        Task<bool> SaveTripAsync(Trip trip);
        Task<VehicleTrip?> GetTripsSummaryAsync(Guid vehicleId, DateTime startDate, DateTime endDate);
    }
}
