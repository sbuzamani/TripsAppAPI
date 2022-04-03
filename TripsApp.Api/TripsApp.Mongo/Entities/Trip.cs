namespace TripsApp.Mongo.Entities
{
    public class Trip : Entity
    {
        public string VehicleId { get; set; }

        public double Distance { get; set; }

        public Int32 CountryId { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
