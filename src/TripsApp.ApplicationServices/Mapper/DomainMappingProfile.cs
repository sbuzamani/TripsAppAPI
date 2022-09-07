using AutoMapper;
using TripsApp.ApplicationServices.Dtos;
using TripsApp.ApplicationServices.Services;
using TripsApp.Domain.Models;

namespace TripsApp.ApplicationServices.Mapper
{
    public class Source<T>
    {
        public T Value { get; set; }
    }

    public class Destination<T>
    {
        public T Value { get; set; }
    }
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<Trip, Mongo.Entities.Trip>().ReverseMap();
            CreateMap<TripDto, Trip>().ReverseMap();
            CreateMap<TripSummaryDto, VehicleSummary>().ReverseMap();
            CreateMap<TripAggregation, Mongo.Entities.TripAggregation>().ReverseMap();
            CreateMap<Vehicle, Mongo.Entities.Vehicle>().ReverseMap();
            CreateMap(typeof(Source<>), typeof(Destination<>));
        }
    }
}
