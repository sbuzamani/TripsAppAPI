namespace TripsApp.Mongo.Entities
{
    public class Vehicle : Entity
    {
        public Guid VehicleId { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public int CountryId { get; set; }
    }
}
