using FluentValidation.AspNetCore;
using TripsApp.Api.Constants;
using TripsApp.Api.Extensions;
using TripsApp.ApplicationServices.IoC;
using TripsApp.Mongo.IoC;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration[ConfigurationConstants.ConnectionStringName];
var databaseName = builder.Configuration[ConfigurationConstants.DatabaseName];

// Add services to the container.
builder.Services.AddRepositories(connectionString, databaseName);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddMediatRApi();
builder.Services.AddFluentValidation(FluentValidationMvcConfiguration =>
FluentValidationMvcConfiguration.RegisterValidatorsFromAssemblyContaining<IStartup>());

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