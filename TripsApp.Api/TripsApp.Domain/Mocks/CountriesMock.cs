using TripsApp.Domain.Models;

namespace TripsApp.Domain.Mocks
{
    public static class CountriesMock
    {
        public static IEnumerable<Country> GetCountries()
        {
            return new List<Country>
            {
                new Country
                {
                    CountryId = 144,
                    Name = "USA",
                    FuelPrice = 4
                },
                new Country
                {
                    CountryId= 145,
                    Name="China",
                    FuelPrice=3
                },
                new Country
                {
                    CountryId=146,
                    Name = "Japan",
                    FuelPrice = (decimal)4.444f
                }
            };
        }
    }
}
