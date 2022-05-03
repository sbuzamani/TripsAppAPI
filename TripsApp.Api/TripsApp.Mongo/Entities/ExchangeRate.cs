namespace TripsApp.Mongo.Entities
{
    public class ExchangeRate : Entity
    {
        public Guid CountryId { get; set; }

        public double Rate { get; set; }

        public string CurrencyCode { get; set; }
    }
}
