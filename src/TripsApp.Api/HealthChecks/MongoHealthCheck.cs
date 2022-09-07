using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Bson;
using MongoDB.Driver;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Api.HealthChecks
{
    public class MongoHealthCheck : IHealthCheck
    {
        private IMongoContext _mongoContext;
        private IMongoDatabase _database;
        public MongoHealthCheck(IMongoContext mongoContext)
        {
            _mongoContext = mongoContext;
            _database = _mongoContext.GetDatabase();
        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var isHealthyResult = await CheckConnectionHealthAsync();

            if (isHealthyResult)
            {
                return HealthCheckResult.Healthy("All Okay");
            }
            return HealthCheckResult.Unhealthy("Not Okay");
        }

        private async Task<bool> CheckConnectionHealthAsync()
        {
            try
            {
                await _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}");
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
