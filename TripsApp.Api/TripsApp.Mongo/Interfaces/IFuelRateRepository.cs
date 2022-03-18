using TripsApp.Mongo.Entities;

namespace TripsApp.Mongo.Interfaces
{
    public interface IFuelRateRepository : IRepository<FuelRate>
    {
        Task<decimal> GetAsync();
    }
}
