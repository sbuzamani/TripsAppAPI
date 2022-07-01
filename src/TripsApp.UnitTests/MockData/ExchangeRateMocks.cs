using System;
using TripsApp.Mongo.Entities;

namespace TripsApp.UnitTests.MockData
{
    public static class ExchangeRateMocks
    {
        public static ExchangeRate GetExchangeRate()
        {
            return new ExchangeRate
            {
                CountryId = Guid.Parse("65069da9-608e-4303-b15f-bc63884d1d2e"),
                CurrencyCode = "DZM",
                Id = Guid.NewGuid(),
                Rate = 5.99
            };
        }
        public static ExchangeRate GetZeroExchangeRate()
        {
            return new ExchangeRate
            {
                CountryId = Guid.Parse("65069da9-608e-4303-b15f-bc63884d1d2e"),
                CurrencyCode = "DZM",
                Id = Guid.NewGuid(),
                Rate = 0
            };
        }
    }
}
