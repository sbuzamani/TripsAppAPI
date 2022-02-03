using AutoMapper;
using TripsApp.Domain.Repositories;

namespace TripsApp.ApplicationServices.Services
{
    public class TripService : ITripService
    {
        private ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        public TripService(ITripRepository tripRepository, IMapper mapper)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
        }

        public async Task<bool> SaveTrip(Domain.Models.Trip trip)
        {
            var tripEntity = _mapper.Map<Domain.Repositories.Entities.Trip>(trip);
            var result = await _tripRepository.SaveTrip(tripEntity);
            return result;
        }

        public async Task<List<Domain.Models.Trip>> GetTrips(Guid vehicleId)
        {
            var trips = await _tripRepository.GetTrips(vehicleId);
            if (!trips.Any())
            {
                return new List<Domain.Models.Trip>();
            }
            var result = _mapper.Map<List<Domain.Models.Trip>>(trips);
            return result;
        }
    }
}
