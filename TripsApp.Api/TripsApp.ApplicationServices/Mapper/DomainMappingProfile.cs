using AutoMapper;
using TripsApp.Domain.Models;

namespace TripsApp.ApplicationServices.Mapper
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            CreateMap<Trip, Mongo.Entities.Trip>().ReverseMap();
        }
    }
}
