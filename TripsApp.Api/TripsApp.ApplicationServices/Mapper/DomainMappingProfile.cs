using AutoMapper;
using TripsApp.ApplicationServices.Dtos;
using TripsApp.ApplicationServices.Services;
using TripsApp.Domain.Models;

namespace TripsApp.ApplicationServices.Mapper
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<Trip, Mongo.Entities.Trip>().ReverseMap();
            CreateMap<TripDto, Trip>().ReverseMap();
            CreateMap<TripResponse, VehicleSummary>().ReverseMap();
        }
    }
}
