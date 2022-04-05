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
                    Distance = 55.6,
                    TimeStamp = new DateTime(2020,06,05),
                    VehicleId = new Guid()
                },
                new Trip
                {
                    CountryId = 145,
                    Distance = 155.6,
                    TimeStamp = new DateTime(2020,06,05),
                    VehicleId = new Guid()
                },
                new Trip
                {
                    CountryId = 146,
                    Distance = 160.00,
                    TimeStamp = new DateTime(2020,06,05),
                    VehicleId = new Guid()
                }
            };
        }
    }
}
