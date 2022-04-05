using System;
using System.Collections.Generic;
using TripsApp.Domain.Models;

namespace TripsApp.UnitTests.MockData
{
    public static class TripsMocks
    {
        public static Trip GetTrip()
        {
            return new Trip()
            {
                CountryId = 1,
                Distance = 3.3,
                TimeStamp = DateTime.Now,
                VehicleId = new Guid()
            };
        }

        public static IEnumerable<Trip> GetTripList()
        {
            return new List<Trip>()
            {
                new Trip{
                    CountryId = 1,
                    Distance = 30.3,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Trip
                {
                    CountryId = 2,
                    Distance = 35.53,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Trip
                {
                    CountryId = 3,
                    Distance = 500.8,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                }
            };
        }

        public static List<Mongo.Entities.Trip> GetTripEntityList()
        {
            return new List<Mongo.Entities.Trip>()
            {
                new Mongo.Entities.Trip
                {
                    CountryId = 3,
                    Distance = 12,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Mongo.Entities.Trip
                {
                    CountryId = 3,
                    Distance = 11,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Mongo.Entities.Trip
                {
                    CountryId = 3,
                    Distance = 10,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                }
            };
        }

        public static List<Mongo.Entities.Trip> GetZeroDistanceTripEntityList()
        {
            return new List<Mongo.Entities.Trip>()
            {
                new Mongo.Entities.Trip
                {
                    CountryId = 3,
                    Distance = 0,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Mongo.Entities.Trip
                {
                    CountryId = 3,
                    Distance = 0,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Mongo.Entities.Trip
                {
                    CountryId = 3,
                    Distance = 0,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                }
            };
        }

        public static Trip GetSaveTrip()
        {
            return new Trip
            {
                VehicleId = Guid.NewGuid(),
                CountryId = 1,
                Distance = 5,
                TimeStamp = DateTime.Now
            };
        }
    }
}
