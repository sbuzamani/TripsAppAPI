namespace TripsApp.Mongo.Entities
{
    public class Country : Entity
    {
        public int CountryId { get; set; }

        public string Name { get; set; }

        public decimal FuelPrice { get; set; }
    }
}
