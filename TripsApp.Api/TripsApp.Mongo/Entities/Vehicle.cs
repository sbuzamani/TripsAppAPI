using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Entities
{
    public class Vehicle : IEntity
    {
        public Guid Id { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public int CountryId { get; set; }
    }
}
