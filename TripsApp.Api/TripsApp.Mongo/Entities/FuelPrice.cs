namespace TripsApp.Mongo.Entities
{
    public class FuelPrice : Entity
    {
        public int CountryId { get; set; }

        public decimal Price { get; set; }
    }
}
