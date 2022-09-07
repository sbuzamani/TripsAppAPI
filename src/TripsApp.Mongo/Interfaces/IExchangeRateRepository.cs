using TripsApp.Mongo.Entities;

namespace TripsApp.Mongo.Interfaces
{
    public interface IExchangeRateRepository : IRepository<ExchangeRate>
    {
        Task<ExchangeRate> GetByCountryIdAsync(Guid countryId);
    }
}
