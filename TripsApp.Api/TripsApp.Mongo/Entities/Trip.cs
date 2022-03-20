namespace TripsApp.Mongo.Entities
{
    public class Trip : Entity
    {
        public Guid TripId { get; set; }

        public Guid VehicleId { get; set; }

        public decimal Distance { get; set; }

        public int CountryId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
