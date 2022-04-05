using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TripsApp.Api.Commands;
using TripsApp.Api.Queries;

namespace TripsApp.Api.Extensions
{
    public static class MediatrExtensions
    {
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(typeof(SaveTripCommand));
            services.AddMediatR(typeof(GetTripSummaryQuery));
        }
    }
}