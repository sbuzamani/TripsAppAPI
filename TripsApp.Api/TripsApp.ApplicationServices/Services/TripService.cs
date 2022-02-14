using AutoMapper;
using Microsoft.Extensions.Logging;
using TripsApp.Domain.Models;
using TripsApp.Domain.Repositories;

namespace TripsApp.ApplicationServices.Services
{
    public class TripService : ITripService
    {
        private ITripRepository _tripRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public TripService(ITripRepository tripRepository, IMapper mapper, ILogger<TripService> logger)
        {
            _tripRepository = tripRepository;
            _mapper = mapper;
            _logger = logger ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> SaveTripAsync(Trip trip)
        {
            var tripEntity = _mapper.Map<Domain.Repositories.Entities.Trip>(trip);
            bool result = false;

            try
            {
                result = await _tripRepository.SaveTripAsync(tripEntity);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"failed to save {trip.ToString()}");
            }

            return result;
        }

        public async Task<VehicleSummary?> GetTripsSummaryAsync(Guid vehicleId, DateTime startDate, DateTime endDate)
        {
            List<Domain.Repositories.Entities.Trip> trips = new List<Domain.Repositories.Entities.Trip>();

            try
            {
                trips = await _tripRepository.GetVehicleTripsAsync(vehicleId, startDate, endDate);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Unable to complete query {vehicleId}");
            }

            if (!trips.Any() || trips == null)
            {
                return null;
            }

            var result = _mapper.Map<List<Trip>>(trips);
            var tripSummary = await CalculateTripsSummaryAsync(result);

            return tripSummary;
        }
        private async Task<VehicleSummary> CalculateTripsSummaryAsync(IEnumerable<Trip> trips)
        {
            var exchangeRate = await _tripRepository.GetExchangeRateAsync(trips.First().CountryId);
            var costPerKilometer = await _tripRepository.GetCostPerKilometerAsync();
            var totalDistance = CalculateTotalDistance(trips);
            var totalCost = (exchangeRate * costPerKilometer) * totalDistance;

            return new VehicleSummary
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
