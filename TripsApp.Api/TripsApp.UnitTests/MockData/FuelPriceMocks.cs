using TripsApp.Mongo.Entities;

namespace TripsApp.UnitTests.MockData
{
    public class FuelPriceMocks
    {
        public static FuelPrice GetOneFuelPrice()
        {
            return new FuelPrice
            {
                Price = 5.99M,
                CountryId = 3,
                Id = ""
            };
        }
    }
}
