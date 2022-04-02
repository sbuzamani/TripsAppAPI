using TripsApp.Mongo.Entities;

namespace TripsApp.UnitTests.MockData
{
    public static class CountryMocks
    {
        public static Country GetOneCountry()
        {
            return new Country
            {
                CountryId = 1,
                Id = "",
                Name = "Zamunda"
            };
        }
    }
}
