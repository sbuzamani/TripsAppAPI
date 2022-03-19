using TripsApp.Mongo.Interfaces;

namespace TripsApp.Mongo.Entities
{
    public class ExchangeRate : IEntity
    {
        public int CountryId { get; set; }

        public decimal Rate { get; set; }

        public string CurrencyCode { get; set; }
    }
}
