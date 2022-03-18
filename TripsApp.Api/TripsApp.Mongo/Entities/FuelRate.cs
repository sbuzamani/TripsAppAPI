using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Entities
{
    public class FuelRate : IEntity
    {
        public decimal Rate { get; set; }
    }
}
