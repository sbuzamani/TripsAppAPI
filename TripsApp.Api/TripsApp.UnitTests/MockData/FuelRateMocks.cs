using System;
using TripsApp.Mongo.Entities;

namespace TripsApp.UnitTests.MockData
{
    public static class FuelRateMocks
    {
        public static FuelRate GetOneFuelRate()
        {
            return new FuelRate
            {
                Id = Guid.NewGuid(),
                Rate = 2
            };
        }
    }
}
