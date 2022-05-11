using MongoDB.Driver;
using System.Linq.Expressions;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;
using TripsApp.Mongo.IoC;

namespace TripsApp.Mongo.Repositories
{
    public class ExchangeRateRepository : Repository<ExchangeRate>, IExchangeRateRepository
    {
        public ExchangeRateRepository(IMongoContext mongoContext) : base(mongoContext)
        {
        }
    }
}
