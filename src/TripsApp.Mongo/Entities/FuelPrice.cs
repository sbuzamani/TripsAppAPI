using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Entities
{
    public class FuelPrice : Entity, IEntity
    {
        public Guid CountryId { get; set; }

        public double Price { get; set; }
    }
}
