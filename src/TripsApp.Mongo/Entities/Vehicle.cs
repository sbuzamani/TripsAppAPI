namespace TripsApp.Mongo.Entities
{
    public class Vehicle : Entity
    {
        public string Make { get; set; }

        public int Year { get; set; }

        public Guid CountryId { get; set; }
    }
}
