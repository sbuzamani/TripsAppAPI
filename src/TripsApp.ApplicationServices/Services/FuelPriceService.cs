using AutoMapper;
using TripsApp.ApplicationServices.Interfaces;
using TripsApp.Domain.Models;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.ApplicationServices.Services
{
    public class FuelPriceService : BaseService<FuelPrice, Mongo.Entities.FuelPrice>, IFuelPriceService
    {
        public FuelPriceService(IFuelPriceRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
