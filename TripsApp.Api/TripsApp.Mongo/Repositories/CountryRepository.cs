using TripsApp.Mongo.Entities;
using TripsApp.Mongo.Interfaces;
using TripsApp.Mongo.IoC;

namespace TripsApp.Mongo.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(IMongoContext mongoContext) : base(mongoContext)
        {
        }
    }
}
