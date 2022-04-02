namespace TripsApp.Domain.Models
{
    public class ExchangeRate
    {
        public int CountryId { get; set; }

        public decimal Rate { get; set; }

        public string CurrencyCode { get; set; }
    }
}
