using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Entities
{
    public class Trip : IEntity
    {
        public Guid Id { get; set; }

        public Guid VehicleId { get; set; }

        public decimal Distance { get; set; }

        public int CountryId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
