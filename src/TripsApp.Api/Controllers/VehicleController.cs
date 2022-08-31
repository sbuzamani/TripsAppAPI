using Microsoft.AspNetCore.Mvc;
using TripsApp.ApplicationServices.Interfaces;
using TripsApp.Domain.Models;

namespace TripsApp.Api.Controllers
{
    [ApiController]
    public class VehicleController : BaseController<Vehicle, Mongo.Entities.Vehicle>
    {
        public VehicleController(IVehicleService vehicleService) : base(vehicleService)
        {

        }
    }
}
