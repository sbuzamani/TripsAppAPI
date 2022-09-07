using TripsApp.Mongo.Entities;

namespace TripsApp.Mongo.Interfaces
{
    public interface IFuelPriceRepository : IRepository<FuelPrice>
    {
        Task<FuelPrice> GetByCountryIdAsync(Guid countryId);
    }
}
