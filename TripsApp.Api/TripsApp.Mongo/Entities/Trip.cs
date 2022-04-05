using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TripsApp.Mongo.Entities
{
    public class Trip : Entity
    {
        [BsonRepresentation(BsonType.Binary)]
        public Guid VehicleId { get; set; }

        public double Distance { get; set; }

        public Int32 CountryId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
