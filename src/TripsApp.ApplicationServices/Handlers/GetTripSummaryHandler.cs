using AutoMapper;
using MediatR;
using TripsApp.ApplicationServices.Dtos;
using TripsApp.Api.Queries;
using TripsApp.ApplicationServices.Interfaces;

namespace TripsApp.Api.Handlers
{
    public class GetTripSummaryHandler : IRequestHandler<GetTripSummaryQuery, TripSummaryDto>
    {
        private readonly ITripService _tripService;
        private readonly IMapper _mapper;
        public GetTripSummaryHandler(ITripService tripService, IMapper mapper)
        {
            _tripService = tripService;
            _mapper = mapper;
        }

        public async Task<TripSummaryDto> Handle(GetTripSummaryQuery request, CancellationToken cancellationToken)
        {
            var result = await _tripService.GetTripsSummaryAsync(request.VehicleId, request.StartDate, request.EndDate);

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<TripSummaryDto>(result);
        }
    }
}
