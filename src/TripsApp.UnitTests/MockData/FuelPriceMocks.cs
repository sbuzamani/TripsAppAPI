using System;
using TripsApp.Mongo.Entities;

namespace TripsApp.UnitTests.MockData
{
    public class FuelPriceMocks
    {
        public static FuelPrice GetOneFuelPrice()
        {
            return new FuelPrice
            {
                Price = 5.99,
                CountryId = Guid.Parse("65069da9-608e-4303-b15f-bc63884d1d2e"),
                Id = Guid.NewGuid()
            };
        }
    }
}
