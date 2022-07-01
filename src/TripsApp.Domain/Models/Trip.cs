namespace TripsApp.Domain.Models
{
    public class Trip
    {
        public Guid VehicleId { get; set; }

        public double Distance { get; set; }

        public Guid CountryId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}