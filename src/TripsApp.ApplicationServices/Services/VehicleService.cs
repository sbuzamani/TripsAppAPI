using AutoMapper;
using TripsApp.ApplicationServices.Interfaces;
using TripsApp.Domain.Models;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.ApplicationServices.Services
{
    public class VehicleService : BaseService<Vehicle, Mongo.Entities.Vehicle>, IVehicleService
    {
        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper) : base(vehicleRepository, mapper)
        {
        }
    }
}
