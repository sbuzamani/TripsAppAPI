namespace TripsApp.Mongo.Entities
{
    public class TripAggregation
    {
        public Guid VehicleId { get; set; }

        public Guid CountryId { get; set; }

        public double TotalDistance { get; set; }
    }
}
