namespace TripsApp.Domain.Models
{
    public class TripAggregation
    {
        public Guid VehicleId { get; set; }

        public Guid CountryId { get; set; }

        public double TotalDistance { get; set; }
    }
}
