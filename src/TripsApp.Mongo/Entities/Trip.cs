using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TripsApp.Mongo.Entities
{
    public class Trip : Entity
    {
        [BsonRepresentation(BsonType.String)]
        public Guid VehicleId { get; set; }

        public double Distance { get; set; }

        [BsonRepresentation(BsonType.String)]
        public Guid CountryId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
