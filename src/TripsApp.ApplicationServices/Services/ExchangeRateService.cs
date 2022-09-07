using AutoMapper;
using TripsApp.ApplicationServices.Interfaces;
using TripsApp.Domain.Models;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.ApplicationServices.Services
{
    public class ExchangeRateService : BaseService<ExchangeRate, Mongo.Entities.ExchangeRate>, IExchangeRateService
    {
        public ExchangeRateService(IExchangeRateRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
