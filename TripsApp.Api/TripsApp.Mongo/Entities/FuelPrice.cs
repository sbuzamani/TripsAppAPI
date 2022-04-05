namespace TripsApp.Mongo.Entities
{
    public class FuelPrice : Entity
    {
        public int CountryId { get; set; }

        public double Price { get; set; }
    }
}
