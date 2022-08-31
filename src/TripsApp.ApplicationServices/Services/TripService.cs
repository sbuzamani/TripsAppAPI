using AutoMapper;
using Microsoft.Extensions.Logging;
using TripsApp.ApplicationServices.Interfaces;
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

            result = await _tripRepository.SaveAsync(tripEntity);

            return result;
        }

        public async Task<VehicleSummary?> GetTripsSummaryAsync(Guid vehicleId, DateTime startDate, DateTime endDate)
        {
            var tripAggregation = await _tripRepository.GetTripAggregationAsync(vehicleId, startDate, endDate);

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
            var exchangeRate = _exchangeRateRepository.GetByCountryIdAsync(tripAggregation.CountryId);

            var fuelPrice = _fuelPriceRepository.GetByCountryIdAsync(tripAggregation.CountryId);

            var country = _countryRepository.GetAsync(tripAggregation.CountryId);

            var totalDistance = tripAggregation.TotalDistance;
            var totalCost = (await exchangeRate).Rate * (await fuelPrice).Price * totalDistance;
            var estimatedCost = totalDistance * costPerKilometer;

            return new VehicleSummary
            {
                CalculatedCost = totalCost,
                VehicleId = tripAggregation.VehicleId,
                TotalDistance = totalDistance,
                EstimatedCost = estimatedCost,
                Country = (await country).Name,
            };
        }
    }
}