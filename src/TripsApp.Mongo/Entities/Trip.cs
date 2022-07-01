using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TripsApp.Mongo.Entities
{
    public class Trip : Entity
    {
        [BsonRepresentation(BsonType.Binary)]
        public Guid VehicleId { get; set; }

        public double Distance { get; set; }

        [BsonRepresentation(BsonType.Binary)]
        public Guid CountryId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
