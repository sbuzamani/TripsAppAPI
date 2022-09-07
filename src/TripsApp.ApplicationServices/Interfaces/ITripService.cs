using TripsApp.ApplicationServices.Services;
using TripsApp.Domain.Models;

namespace TripsApp.ApplicationServices.Interfaces
{
    public interface ITripService
    {
        Task<bool> SaveTripAsync(Trip trip);
        Task<VehicleSummary?> GetTripsSummaryAsync(Guid vehicleId, DateTime startDate, DateTime endDate);
    }
}
