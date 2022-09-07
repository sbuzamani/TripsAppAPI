using Microsoft.Extensions.DependencyInjection;
using TripsApp.ApplicationServices.Interfaces;
using TripsApp.ApplicationServices.Mapper;
using TripsApp.ApplicationServices.Services;

namespace TripsApp.ApplicationServices.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ITripService, TripService>();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IFuelPriceService, FuelPriceService>();
            services.AddTransient<IExchangeRateService, ExchangeRateService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddAutoMapper(typeof(DomainMappingProfile));
        }
    }
}
