using MongoDB.Driver;
using System.Linq.Expressions;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repository
{
    public class ExchangeRateRepository : Repository<ExchangeRate>, IExchangeRateRepository
    {
        public ExchangeRateRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }
    }
}
