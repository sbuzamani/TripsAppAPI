using FluentValidation;
using FluentValidation.AspNetCore;
using TripsApp.Api.Constants;
using TripsApp.Api.Extensions;
using TripsApp.Api.Middleware;
using TripsApp.Api.Requests;
using TripsApp.Api.Validators;
using TripsApp.ApplicationServices.Dtos;
using TripsApp.ApplicationServices.IoC;
using TripsApp.Mongo.IoC;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration[ConfigurationConstants.ConnectionStringName];
var databaseName = builder.Configuration[ConfigurationConstants.DatabaseName];

builder.Services.AddRepositories(connectionString, databaseName);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddApplicationServices();
builder.Services.AddMediatRApi();
builder.Services.AddFluentValidation(FluentValidationMvcConfiguration =>
FluentValidationMvcConfiguration.RegisterValidatorsFromAssemblyContaining<IStartup>());
builder.Services.AddTransient<IValidator<TripSummaryRequest>, TripSummaryRequestValidator>();
builder.Services.AddTransient<IValidator<TripDto>, SaveTripValidator>();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCustomMiddleware(app.Environment);
app.UseHttpLogging();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHealthChecks(PathConstants.HealthCheckPath, new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
    {
        Predicate = (check) => check.Tags.Contains("all")
    });
});

app.Run();