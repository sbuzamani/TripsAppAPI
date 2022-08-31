using System;
using TripsApp.Mongo.Entities;

namespace TripsApp.UnitTests.MockData
{
    public static class TripRepositoryMock
    {
        public static Trip OneTripEntity()
        {
            return new Trip
            {
                Id = Guid.Parse("c4a484b7-2b31-4edf-b951-3a85557d0268"),
                VehicleId = new Guid(),
                CountryId = new Guid(),
                Distance = 50.0,
                TimeStamp = DateTime.Now
            };
        }

        public static TripAggregation OneTripAggregation()
        {
            return new TripAggregation
            {
                CountryId = new Guid(),
                VehicleId = new Guid(),
                TotalDistance = 487587.90f
            };
        }
    }
}
