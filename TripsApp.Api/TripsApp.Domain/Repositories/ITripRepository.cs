using TripsApp.Domain.Repositories.Entities;

namespace TripsApp.Domain.Repositories
{
    public interface ITripRepository
    {
        Task<bool> SaveTrip(Trip trip);
        Task<List<Trip>> GetTrips(Guid guid);
    }
}
