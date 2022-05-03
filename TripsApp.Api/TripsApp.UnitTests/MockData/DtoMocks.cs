using System;
using TripsApp.ApplicationServices.Dtos;
using TripsApp.ApplicationServices.Services;

namespace TripsApp.UnitTests.MockData
{
    public static class DtoMocks
    {
        public static TripSummaryDto TripResponseMock()
        {
            return new TripSummaryDto
            {
                VehicleId = new Guid(),
                CalculatedCost = 99.9,
                TotalDistance = 99.9
            };
        }

        public static VehicleSummary GetVehicleTrip()
        {
            return new VehicleSummary
            {
                VehicleId = Guid.NewGuid(),
                CalculatedCost = 5,
                TotalDistance = 5
            };
        }

        public static TripDto GetTripDto()
        {
            return new TripDto
            {
                VehicleId = Guid.NewGuid(),
                CountryId = Guid.NewGuid(),
                Distance = 5,
                TimeStamp = DateTime.Now
            };
        }
    }
}
