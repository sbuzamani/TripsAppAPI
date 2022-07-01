namespace TripsApp.Mongo.Entities
{
    public class FuelPrice : Entity
    {
        public Guid CountryId { get; set; }

        public double Price { get; set; }
    }
}
