using System;
using TripsApp.Api.Requests;

namespace TripsApp.UnitTests.MockData
{
    public static class TripSummaryRequestMock
    {
        public static TripSummaryRequest GetTripSummaryRequest()
        {
            return new TripSummaryRequest
            {
                VehicleId = new Guid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            };
        }
    }
}
