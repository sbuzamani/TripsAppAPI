using TripsApp.Domain.Models;

namespace TripsApp.ApplicationServices.Interfaces
{
    public interface ICountryService : IBaseService<Country, Mongo.Entities.Country>
    {
    }
}
