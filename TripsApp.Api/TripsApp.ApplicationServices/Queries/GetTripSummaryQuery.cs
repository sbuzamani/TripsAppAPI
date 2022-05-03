using MediatR;
using TripsApp.ApplicationServices.Dtos;

namespace TripsApp.Api.Queries
{
    public class GetTripSummaryQuery : IRequest<TripSummaryDto>
    {
        public Guid VehicleId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public GetTripSummaryQuery(Guid vehicleId, DateTime startDate, DateTime endDate)
        {
            VehicleId = vehicleId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
