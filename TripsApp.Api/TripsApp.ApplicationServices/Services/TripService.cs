using AutoMapper;
using Microsoft.Extensions.Logging;
using TripsApp.Domain.Models;
using TripsApp.Mongo.Interfaces;

namespace TripsApp.ApplicationServices.Services
{
    public class TripService : ITripService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ITripRepository _tripRepository;
        private readonly IExchangeRateRepository _exchangeRateRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IFuelRateRepository _fuelRateRepository;
        private readonly IFuelPriceRepository _fuelPriceRepository;
        public TripService(IMapper mapper, ILogger<TripService> logger, ITripRepository tripRepository,
            IExchangeRateRepository exchangeRateRepository, ICountryRepository countryRepository, IFuelRateRepository fuelRateRepository,
            IFuelPriceRepository fuelPriceRepository)
        {
            _mapper = mapper;
            _logger = logger ?? throw new ArgumentNullException(nameof(mapper));
            _tripRepository = tripRepository;
            _exchangeRateRepository = exchangeRateRepository;
            _countryRepository = countryRepository;
            _fuelRateRepository = fuelRateRepository;
            _fuelPriceRepository = fuelPriceRepository;
        }

        public async Task<bool> SaveTripAsync(Trip trip)
        {
            var tripEntity = _mapper.Map<Mongo.Entities.Trip>(trip);
            bool result = false;

            try
            {
                result = await _tripRepository.SaveAsync(tripEntity);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"failed to save {trip.ToString()}");
            }

            return result;
        }

        public async Task<VehicleSummary?> GetTripsSummaryAsync(Guid vehicleId, DateTime startDate, DateTime endDate)
        {
            IEnumerable<Mongo.Entities.Trip> trips = new List<Mongo.Entities.Trip>();

            try
            {
                trips = await _tripRepository.ListAsync(vehicleId, startDate, endDate);
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
            var countryId = trips.First().CountryId;
            var exchangeRate = await _exchangeRateRepository.GetAsync(countryId);
            var costPerKilometer = await _fuelRateRepository.GetAsync();
            var fuelPrice = await _fuelPriceRepository.GetFuelPriceAsync(countryId);
            var countryName = await _countryRepository.GetAsync(countryId);
            var totalDistance = CalculateTotalDistance(trips);
            var totalCost = exchangeRate.Rate * (fuelPrice.Price * totalDistance);
            var estimatedCost = totalDistance * costPerKilometer;

            return new VehicleSummary
            {
                CalculatedCost = totalCost,
                VehicleId = trips.First().VehicleId,
                TotalDistance = totalDistance,
                EstimatedCost = estimatedCost,
                Country = countryName?.Name,
            };
        }
        private double CalculateTotalDistance(IEnumerable<Trip> trips)
        {
            var result = 0.0;

            foreach (var trip in trips)
            {
                result += trip.Distance;
            }

            return result;
        }
    }
}
