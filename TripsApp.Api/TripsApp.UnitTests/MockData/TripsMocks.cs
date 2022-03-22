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
                TripId = new Guid(),
                CountryId = 1,
                Distance = 3.3M,
                TimeStamp = DateTime.Now,
                VehicleId = new Guid()
            };
        }

        public static IEnumerable<Trip> GetTripList()
        {
            return new List<Trip>()
            {
                new Trip{
                    TripId = new Guid(),
                    CountryId = 1,
                    Distance = 30.3M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Trip
                {
                    TripId = new Guid(),
                    CountryId = 2,
                    Distance = 35.53M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Trip
                {
                    TripId = new Guid(),
                    CountryId = 3,
                    Distance = 500.8M,
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
                    TripId = new Guid(),
                    CountryId = 3,
                    Distance = 12M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Mongo.Entities.Trip
                {
                    TripId = new Guid(),
                    CountryId = 3,
                    Distance = 11M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Mongo.Entities.Trip
                {
                    TripId = new Guid(),
                    CountryId = 3,
                    Distance = 10M,
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
                    TripId = new Guid(),
                    CountryId = 3,
                    Distance = 0M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Mongo.Entities.Trip
                {
                    TripId = new Guid(),
                    CountryId = 3,
                    Distance = 0M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Mongo.Entities.Trip
                {
                    TripId = new Guid(),
                    CountryId = 3,
                    Distance = 0M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                }
            };
        }

        public static Trip GetSaveTrip()
        {
            return new Trip
            {
                TripId = Guid.NewGuid(),
                VehicleId = Guid.NewGuid(),
                CountryId = 1,
                Distance = 5M,
                TimeStamp = DateTime.Now
            };
        }
    }
}
