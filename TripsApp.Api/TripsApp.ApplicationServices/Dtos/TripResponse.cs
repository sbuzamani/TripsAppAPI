namespace TripsApp.ApplicationServices.Dtos
{
    public class TripResponse
    {
        public Guid VehicleId { get; set; }

        public string Country { get; set; }

        public double TotalDistance { get; set; }

        public double EstimatedCost { get; set; }

        public double CalculatedCost { get; set; }
    }
}
