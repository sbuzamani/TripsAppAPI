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
                    Id = 144,
                    Name = "USA",
                    FuelPrice = 4
                },
                new Country
                {
                    Id= 145,
                    Name="China",
                    FuelPrice=3
                },
                new Country 
                {
                    Id=146,
                    Name = "Japan",
                    FuelPrice = (decimal)4.444f
                }
            };
        }
    }
}
