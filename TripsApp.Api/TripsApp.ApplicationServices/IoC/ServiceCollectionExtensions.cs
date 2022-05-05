using Microsoft.Extensions.DependencyInjection;
using TripsApp.ApplicationServices.Mapper;
using TripsApp.ApplicationServices.Services;

namespace TripsApp.ApplicationServices.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ITripService, TripService>();
            services.AddAutoMapper(typeof(DomainMappingProfile));
        }
    }
}
