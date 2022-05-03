using TripsApp.Mongo.Entities;

namespace TripsApp.Mongo.Interfaces
{
    public interface IFuelPriceRepository : IRepository<FuelPrice>
    {
        Task<FuelPrice> GetFuelPriceAsync(Guid countryId);
    }
}
