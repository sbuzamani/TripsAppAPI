using System;
using TripsApp.Api.Dtos;
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
                CalculatedCost = 99.9M,
                TotalKms = 99.9M
            };
        }

        public static VehicleSummary GetVehicleTrip()
        {
            return new VehicleSummary
            {
                VehicleId = Guid.NewGuid(),
                CalculatedCost = 5M,
                TotalKms = 5M
            };
        }

        public static TripDto GetTripDto()
        {
            return new TripDto
            {
                VehicleId = Guid.NewGuid(),
                CountryId = 1,
                Distance = 5M,
                TimeStamp = DateTime.Now
            };
        }
    }
}
