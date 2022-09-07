using TripsApp.Domain.Models;

namespace TripsApp.ApplicationServices.Interfaces
{
    public interface IVehicleService : IBaseService<Vehicle, Mongo.Entities.Vehicle>
    {
    }
}
