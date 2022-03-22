﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TripsApp.Mongo.Entities
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
