using TripsApp.Domain.Models;

namespace TripsApp.Domain.Mocks
{
    public static class VehiclesMock
    {
        public static IEnumerable<Vehicle> GetVehicles()
        {
            return new List<Vehicle>{
                new Vehicle
                {
                    Id = new Guid(),
                    CountryId = 144,
                    Make = "Porsche",
                    Year = 2011
                },
                new Vehicle
                {
                    Id = new Guid(),
                    CountryId = 145,
                    Make = "Porsche",
                    Year = 2011
                },
                new Vehicle
                {
                    Id = new Guid(),
                    CountryId = 145,
                    Make = "Porsche",
                    Year = 2011
                },
                new Vehicle
                {
                    Id = new Guid(),
                    CountryId = 146,
                    Make = "Porsche",
                    Year = 2011
                }
            };
        }
    }
}
