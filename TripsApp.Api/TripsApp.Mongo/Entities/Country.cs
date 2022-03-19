using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Entities
{
    public class Country : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal FuelPrice { get; set; }
    }
}
