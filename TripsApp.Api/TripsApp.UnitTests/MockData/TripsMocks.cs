using System;
using System.Collections.Generic;
using TripsApp.Domain.Models;

namespace TripsApp.UnitTests.MockData
{
    public static class TripsMocks
    {
        public static Trip GetTrip()
        {
            return new Trip
            {
                Id = new Guid(),
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
                    Id = new Guid(),
                    CountryId = 1,
                    Distance = 30.3M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Trip
                {
                    Id = new Guid(),
                    CountryId = 2,
                    Distance = 35.53M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Trip
                {
                    Id = new Guid(),
                    CountryId = 3,
                    Distance = 500.8M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                }
            };
        }

        public static List<Domain.Repositories.Entities.Trip> GetTripEntityList()
        {
            return new List<Domain.Repositories.Entities.Trip>()
            {
                new Domain.Repositories.Entities.Trip{
                    Id = new Guid(),
                    CountryId = 3,
                    Distance = 12M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Domain.Repositories.Entities.Trip
                {
                    Id = new Guid(),
                    CountryId = 3,
                    Distance = 11M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Domain.Repositories.Entities.Trip
                {
                    Id = new Guid(),
                    CountryId = 3,
                    Distance = 10M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                }
            };
        }

        public static List<Domain.Repositories.Entities.Trip> GetZeroDistanceTripEntityList()
        {
            return new List<Domain.Repositories.Entities.Trip>()
            {
                new Domain.Repositories.Entities.Trip{
                    Id = new Guid(),
                    CountryId = 3,
                    Distance = 0M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Domain.Repositories.Entities.Trip
                {
                    Id = new Guid(),
                    CountryId = 3,
                    Distance = 0M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                },
                new Domain.Repositories.Entities.Trip
                {
                    Id = new Guid(),
                    CountryId = 3,
                    Distance = 0M,
                    TimeStamp = DateTime.Now,
                    VehicleId = new Guid()
                }
            };
        }
    }
}
