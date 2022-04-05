using System;
using TripsApp.ApplicationServices.Dtos;
using TripsApp.ApplicationServices.Services;

namespace TripsApp.UnitTests.MockData
{
    public static class DtoMocks
    {
        public static TripRequest TripRequestMock()
        {
            return new TripRequest
            {
                VehicleId = new Guid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
        }

        public static TripResponse TripResponseMock()
        {
            return new TripResponse
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
                CountryId = 1,
                Distance = 5,
                TimeStamp = DateTime.Now
            };
        }
    }
}
