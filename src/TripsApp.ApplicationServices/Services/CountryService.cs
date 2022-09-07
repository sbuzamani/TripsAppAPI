using AutoMapper;
using TripsApp.ApplicationServices.Interfaces;
using TripsApp.Domain.Models;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.ApplicationServices.Services
{
    public class CountryService : BaseService<Country, Mongo.Entities.Country>, ICountryService
    {
        public CountryService(ICountryRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
