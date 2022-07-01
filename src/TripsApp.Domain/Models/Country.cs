namespace TripsApp.Domain.Models
{
    public class Country
    {
        public Guid CountryId { get; set; }

        public string Name { get; set; }

        public decimal FuelPrice { get; set; }
    }
}
