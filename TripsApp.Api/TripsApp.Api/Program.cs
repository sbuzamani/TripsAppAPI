using TripsApp.Api.Constants;
using TripsApp.Api.Extensions;
using TripsApp.ApplicationServices.IoC;
using TripsApp.ApplicationServices.Services;
using TripsApp.Mongo.Interfaces;
using TripsApp.Mongo.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration[ConfigurationConstants.ConnectionStringName];
var databaseName = builder.Configuration[ConfigurationConstants.DatabaseName];

// Add services to the container.
builder.Services.AddTransient<ITripRepository>(c =>
{
    return new TripRepository(connectionString, databaseName);
});
builder.Services.AddTransient<ICountryRepository>(c =>
{
    return new CountryRepository(connectionString, databaseName);
});
builder.Services.AddTransient<IExchangeRateRepository>(c =>
{
    return new ExchangeRateRepository(connectionString, databaseName);
});
builder.Services.AddTransient<IFuelRateRepository>(c =>
{
    return new FuelRateRepository(connectionString, databaseName);
});
builder.Services.AddTransient<IFuelPriceRepository>(c =>
{
    return new FuelPriceRepository(connectionString, databaseName);
});

builder.Services.AddTransient<ITripService, TripService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddMediatRApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();