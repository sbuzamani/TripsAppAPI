namespace TripsApp.Api.Dtos
{
    public class TripDto
    {
        public Guid VehicleId { get; set; }

        public decimal Distance { get; set; }

        public int CountryId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
