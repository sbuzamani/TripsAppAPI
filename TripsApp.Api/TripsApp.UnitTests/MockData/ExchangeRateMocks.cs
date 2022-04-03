using TripsApp.Mongo.Entities;

namespace TripsApp.UnitTests.MockData
{
    public static class ExchangeRateMocks
    {
        public static ExchangeRate GetExchangeRate()
        {
            return new ExchangeRate
            {
                CountryId = 3,
                CurrencyCode = "DZM",
                Id = "",
                Rate = 5.99M
            };
        }
        public static ExchangeRate GetZeroExchangeRate()
        {
            return new ExchangeRate
            {
                CountryId = 3,
                CurrencyCode = "DZM",
                Id = "",
                Rate = 0M
            };
        }
    }
}
