namespace TripsApp.ApplicationServices.Dtos
{
    public class TripRequest
    {
        public Guid VehicleId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
