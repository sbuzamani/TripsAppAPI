using Microsoft.Extensions.DependencyInjection;
using TripsApp.Mongo.Interfaces;
using TripsApp.Mongo.Repository;

namespace TripsApp.Mongo.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection serviceCollection, string connectionString, string databaseName)
        {
            serviceCollection.AddTransient<ITripRepository>(c =>
            {
                return new TripRepository(connectionString, databaseName);
            });
            serviceCollection.AddTransient<ICountryRepository>(c =>
            {
                return new CountryRepository(connectionString, databaseName);
            });
            serviceCollection.AddTransient<IExchangeRateRepository>(c =>
            {
                return new ExchangeRateRepository(connectionString, databaseName);
            });
            serviceCollection.AddTransient<IFuelPriceRepository>(c =>
            {
                return new FuelPriceRepository(connectionString, databaseName);
            });
        }
    }
}
