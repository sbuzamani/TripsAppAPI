namespace TripsApp.ApplicationServices.Services
{
    public class VehicleTrip
    {
        public Guid VehicleId { get; set; }
        public decimal TotalKms { get; set; }
        public decimal CalculatedCost { get; set; }
    }
}