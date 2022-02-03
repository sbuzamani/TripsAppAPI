using Microsoft.Extensions.DependencyInjection;
using TripsApp.ApplicationServices.Mapper;

namespace TripsApp.ApplicationServices.IoC
{
    public static class RegisterServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainMappingProfile));
        }
    }
}
