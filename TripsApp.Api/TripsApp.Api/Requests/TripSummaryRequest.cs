namespace TripsApp.Api.Requests
{
    public class TripSummaryRequest
    {
        public Guid VehicleId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
