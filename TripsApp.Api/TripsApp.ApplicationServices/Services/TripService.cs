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
        private readonly IFuelPriceRepository _fuelPriceRepository;
        private const int costPerKilometer = 2;
        public TripService(IMapper mapper, ILogger<TripService> logger, ITripRepository tripRepository,
            IExchangeRateRepository exchangeRateRepository, ICountryRepository countryRepository,
            IFuelPriceRepository fuelPriceRepository)
        {
            _mapper = mapper;
            _logger = logger ?? throw new ArgumentNullException(nameof(mapper));
            _tripRepository = tripRepository;
            _exchangeRateRepository = exchangeRateRepository;
            _countryRepository = countryRepository;
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
            var tripAggregation = new Mongo.Entities.TripAggregation();

            try
            {
                tripAggregation = await _tripRepository.GetTripAggregationAsync(vehicleId, startDate, endDate);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Unable to complete query for {vehicleId}");
                tripAggregation = null;
            }

            if (tripAggregation == null)
            {
                return null;
            }

            var result = _mapper.Map<TripAggregation>(tripAggregation);
            var tripSummary = await CalculateTripsSummaryAsync(result);

            return tripSummary;
        }
        private async Task<VehicleSummary> CalculateTripsSummaryAsync(TripAggregation tripAggregation)
        {
            var exchangeRate = await _exchangeRateRepository.GetAsync(tripAggregation.CountryId);
            var fuelPrice = await _fuelPriceRepository.GetAsync(tripAggregation.CountryId);
            var country = await _countryRepository.GetAsync(tripAggregation.CountryId);
            var totalDistance = tripAggregation.TotalDistance;
            var totalCost = exchangeRate.Rate * (fuelPrice.Price * totalDistance);
            var estimatedCost = totalDistance * costPerKilometer;

            return new VehicleSummary
            {
                CalculatedCost = totalCost,
                VehicleId = tripAggregation.VehicleId,
                TotalDistance = totalDistance,
                EstimatedCost = estimatedCost,
                Country = country?.Name,
            };
        }
    }
}