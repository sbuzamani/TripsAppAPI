namespace TripsApp.Mongo.Entities
{
    public class Country : Entity
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string CurrencyCode { get; set; }
    }
}
