using MongoDB.Driver;
using System.Linq.Expressions;
using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Repository
{
    public class FuelPriceRepository : Repository<FuelPrice>, IFuelPriceRepository
    {
        public FuelPriceRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
        {
        }
    }
}
