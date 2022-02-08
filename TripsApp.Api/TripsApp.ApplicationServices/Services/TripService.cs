using AutoMapper;
using TripsApp.Domain.Models;
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

        public async Task<bool> SaveTripAsync(Trip trip)
        {
            var tripEntity = _mapper.Map<Domain.Repositories.Entities.Trip>(trip);
            var result = await _tripRepository.SaveTrip(tripEntity);
            return result;
        }

        public async Task<VehicleTrip?> GetTripsSummaryAsync(Guid vehicleId, DateTime startDate, DateTime endDate)
        {
            var trips = await _tripRepository.GetTrips(vehicleId, startDate, endDate);
            if (!trips.Any())
            {
                return null;
            }
            var result = _mapper.Map<List<Trip>>(trips);

            var tripSummary = await CalculateTripsSummaryAsync(result);
            return tripSummary;
        }
        private async Task<VehicleTrip> CalculateTripsSummaryAsync(IEnumerable<Trip> trips)
        {
            var exchangeRate = await _tripRepository.GetExchangeRate(trips.First().CountryId);
            var costPerKilometer = await _tripRepository.GetCostPerKilometer();
            var totalDistance = CalculateTotalDistance(trips);

            var totalCost = (exchangeRate * costPerKilometer) * totalDistance;

            return new VehicleTrip
            {
                CalculatedCost = totalCost,
                VehicleId = trips.First().VehicleId,
                TotalKms = totalDistance
            };
        }
        private decimal CalculateTotalDistance(IEnumerable<Trip> trips)
        {
            var result = 0M;

            foreach (var trip in trips)
            {
                result += trip.Distance;
            }

            return result;
        }
    }

}
