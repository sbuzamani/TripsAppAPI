namespace TripsApp.Domain.Models
{
    public class Country
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string CurrencyCode { get; set; }
    }
}
