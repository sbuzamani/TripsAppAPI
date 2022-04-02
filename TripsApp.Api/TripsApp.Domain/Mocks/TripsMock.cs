using TripsApp.Domain.Models;

namespace TripsApp.Domain.Mocks
{
    public static class TripsMock
    {
        public static IEnumerable<Trip> GetTrips()
        {
            return new List<Trip>
            {
                new Trip
                {
                    CountryId = 144,
                    Distance = (decimal)55.6f,
                    TimeStamp = new DateTime(2020,06,05),
                    VehicleId = new Guid()
                },
                new Trip
                {
                    CountryId = 145,
                    Distance = (decimal)155.6f,
                    TimeStamp = new DateTime(2020,06,05),
                    VehicleId = new Guid()
                },
                new Trip
                {
                    CountryId = 146,
                    Distance = (decimal)160.00f,
                    TimeStamp = new DateTime(2020,06,05),
                    VehicleId = new Guid()
                }
            };
        }
    }
}
