using TripsApp.Domain.Repositories.Entities;

namespace TripsApp.Domain.Repositories
{
    public interface ITripRepository
    {
        Task<bool> SaveTripAsync(Trip trip);
        Task<List<Trip>> GetVehicleTripsAsync(Guid guid, DateTime startDate, DateTime endDate);
        Task<decimal> GetExchangeRateAsync(int countryId);
        Task<decimal> GetCostPerKilometerAsync();
    }
}
