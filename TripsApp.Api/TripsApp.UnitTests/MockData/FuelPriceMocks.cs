using TripsApp.Mongo.Entities;

namespace TripsApp.UnitTests.MockData
{
    public class FuelPriceMocks
    {
        public static FuelPrice GetOneFuelPrice()
        {
            return new FuelPrice
            {
                Price = 5.99,
                CountryId = 3,
                Id = ""
            };
        }
    }
}
