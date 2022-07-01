namespace TripsApp.Domain.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public Guid CountryId { get; set; }
    }
}
