namespace TripsApp.ApplicationServices.Dtos
{
    public class TripDto
    {
        public Guid VehicleId { get; set; }

        public decimal Distance { get; set; }

        public Guid CountryId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
