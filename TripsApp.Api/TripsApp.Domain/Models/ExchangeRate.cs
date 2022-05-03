namespace TripsApp.Domain.Models
{
    public class ExchangeRate
    {
        public Guid CountryId { get; set; }

        public decimal Rate { get; set; }

        public string CurrencyCode { get; set; }
    }
}
