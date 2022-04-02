namespace TripsApp.ApplicationServices.Services
{
    public class VehicleSummary
    {
        public Guid VehicleId { get; set; }
        public string Country { get; set; }
        public decimal TotalKms { get; set; }
        public decimal EstimatedCost { get; set; }
        public decimal CalculatedCost { get; set; }
    }
}