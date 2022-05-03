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
                CountryId = Guid.NewGuid(),
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
                    CountryId = Guid.NewGuid(),
                    Distance = 30.3,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Trip
                {
                    CountryId = Guid.NewGuid(),
                    Distance = 35.53,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Trip
                {
                    CountryId = Guid.NewGuid(),
                    Distance = 500.8,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                }
            };
        }

        public static Mongo.Entities.TripAggregation GetTripEntityList()
        {
            return new Mongo.Entities.TripAggregation
            {
                CountryId = Guid.Parse("65069da9-608e-4303-b15f-bc63884d1d2e"),
                TotalDistance = 35,
                VehicleId = Guid.Parse("a5fcd4ae-13b5-4963-a9d3-619f0d390bee")
            };
        }

        public static Mongo.Entities.TripAggregation GetZeroTotalDistanceTripAggregation()
        {
            return new Mongo.Entities.TripAggregation
            {
                CountryId = Guid.Parse("65069da9-608e-4303-b15f-bc63884d1d2e"),
                TotalDistance = 0,
                VehicleId = Guid.Parse("8ded079c-1ff5-4344-a4dc-a61368be057b"),
            };
        }

        public static Trip GetSaveTrip()
        {
            return new Trip
            {
                VehicleId = Guid.NewGuid(),
                CountryId = Guid.NewGuid(),
                Distance = 5,
                TimeStamp = DateTime.Now
            };
        }
    }
}
