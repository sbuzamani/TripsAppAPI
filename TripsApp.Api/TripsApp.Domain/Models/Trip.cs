namespace TripsApp.Domain.Models
{
    public class Trip
    {
        public Guid TripId { get; set; }

        public Guid VehicleId { get; set; }

        public decimal Distance { get; set; }

        public int CountryId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}