namespace TripsApp.Domain.Models
{
    public class Vehicle
    {
        public Guid VehicleId { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public int CountryId { get; set; }
    }
}
