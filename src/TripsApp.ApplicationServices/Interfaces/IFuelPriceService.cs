using TripsApp.Domain.Models;

namespace TripsApp.ApplicationServices.Interfaces
{
    public interface IFuelPriceService : IBaseService<FuelPrice, Mongo.Entities.FuelPrice>
    {
    }
}
