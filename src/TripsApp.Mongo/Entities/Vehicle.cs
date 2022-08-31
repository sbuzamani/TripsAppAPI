using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Entities
{
    public class Vehicle : Entity, IEntity
    {
        public string Make { get; set; }

        public int Year { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid CountryId { get; set; }
    }
}
