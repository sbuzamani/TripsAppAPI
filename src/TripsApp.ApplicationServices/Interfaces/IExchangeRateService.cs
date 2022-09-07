using TripsApp.Domain.Models;

namespace TripsApp.ApplicationServices.Interfaces
{
    public interface IExchangeRateService : IBaseService<ExchangeRate, Mongo.Entities.ExchangeRate>
    {
    }
}
