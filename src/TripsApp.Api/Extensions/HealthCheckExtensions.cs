using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using System.Net.Mime;
using TripsApp.Api.HealthChecks;

namespace TripsApp.Api.Extensions
{
    public static class HealthCheckExtensions
    {
        private static string _livenessProbePathName;
        private static string _healthProbePathName;
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            _livenessProbePathName = configuration.GetSection("HealthChecks:LivenessProbePathName").Value;
            _healthProbePathName = configuration.GetSection("HealthChecks:HealthCheckPathName").Value;

            services.AddHealthChecks().AddApplicationInsightsPublisher().AddCheck<MongoHealthCheck>("MongoHealthCheck");

            return services;
        }

        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder applicationBuilder)
        {
            var livenessProbe = CreateHealthCheckOptions((report) => new
            {
                status = HealthStatus.Healthy.ToString(),
                errors = new { }
            });

            var healthProbe = CreateHealthCheckOptions((report) => new
            {
                status = $"Trips App Api is: {report.Status}",
                errors = report.Entries.Select(x => new
                {
                    data = x.Value.Data,
                    key = x.Key,
                    status = Enum.GetName(typeof(HealthStatus), x.Value.Status),
                    description = x.Value.Description,
                })
            });
            applicationBuilder.UseHealthChecks(_healthProbePathName, healthProbe);
            applicationBuilder.UseHealthChecks(_livenessProbePathName, livenessProbe);
            return applicationBuilder;
        }

        private static HealthCheckOptions CreateHealthCheckOptions(Func<HealthReport, object> healthCheckOptions)
        {
            return new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = async (context, report) =>
                {
                    var result = JsonConvert.SerializeObject(healthCheckOptions(report));
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(result);
                },
            };
        }
    }
}
