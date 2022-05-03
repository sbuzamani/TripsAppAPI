using System;
using TripsApp.Mongo.Entities;

namespace TripsApp.UnitTests.MockData
{
    public static class CountryMocks
    {
        public static Country GetOneCountry()
        {
            return new Country
            {
                Id = Guid.Parse("65069da9-608e-4303-b15f-bc63884d1d2e"),
                Name = "Zamunda"
            };
        }
    }
}
