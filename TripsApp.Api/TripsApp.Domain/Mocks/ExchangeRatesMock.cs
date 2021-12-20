using TripsApp.Domain.Models;

namespace TripsApp.Domain.Mocks
{
    public static class ExchangeRatesMock
    {
        public static IEnumerable<ExchangeRate> GetExchangeRates()
        {
            return new List<ExchangeRate>
            {
                new ExchangeRate
                {
                    CountryId = 144,
                    Currency = "USD",
                    Rate = 1
                },
                new ExchangeRate
                {
                    CountryId = 144,
                    Currency = "JPY",
                    Rate = (decimal)1.5f
                }
            };
        }
    }
}
