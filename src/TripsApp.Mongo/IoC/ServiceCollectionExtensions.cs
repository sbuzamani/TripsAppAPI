using Microsoft.Extensions.DependencyInjection;
using TripsApp.Mongo.Interfaces;
using TripsApp.Mongo.Repositories;

namespace TripsApp.Mongo.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection, string connectionString, string databaseName)
        {
            serviceCollection.AddSingleton<IMongoContext>(c =>
            {
                return new MongoContext(connectionString, databaseName);
            });

            serviceCollection.AddTransient<ITripRepository, TripRepository>();
            serviceCollection.AddTransient<ICountryRepository, CountryRepository>();
            serviceCollection.AddTransient<IExchangeRateRepository, ExchangeRateRepository>();
            serviceCollection.AddTransient<IFuelPriceRepository, FuelPriceRepository>();
            serviceCollection.AddTransient<IVehicleRepository, VehicleRepository>();
        }
    }
}
