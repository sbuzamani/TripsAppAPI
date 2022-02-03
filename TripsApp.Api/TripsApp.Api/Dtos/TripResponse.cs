namespace TripsApp.Api.Dtos
{
    public class TripResponse
    {
        public Guid VehicleId { get; set; }

        public decimal TotalKms { get; set; }

        public decimal CalculatedCost { get; set; }
    }
}
