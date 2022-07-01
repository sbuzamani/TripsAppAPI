using AutoMapper;
using MediatR;
using TripsApp.Api.Commands;
using TripsApp.ApplicationServices.Services;
using TripsApp.Domain.Models;

namespace TripsApp.Api.Handlers
{
    public class SaveTripHandler : IRequestHandler<SaveTripCommand, bool>
    {
        private readonly ITripService _tripService;
        private readonly IMapper _mapper;

        public SaveTripHandler(ITripService tripService, IMapper mapper)
        {
            _tripService = tripService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(SaveTripCommand request, CancellationToken cancellationToken)
        {
            var tripToSave = _mapper.Map<Trip>(request.TripDto);

            var result = await _tripService.SaveTripAsync(tripToSave);
            
            return true;
        }
    }
}
