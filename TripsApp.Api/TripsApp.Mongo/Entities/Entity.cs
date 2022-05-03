using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TripsApp.Mongo.Entities
{
    public abstract class Entity
    {
        [BsonRepresentation(BsonType.Binary)]
        public virtual Guid Id { get; set; }
    }
}