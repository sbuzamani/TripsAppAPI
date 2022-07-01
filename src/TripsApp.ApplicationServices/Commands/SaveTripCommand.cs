using MediatR;
using TripsApp.ApplicationServices.Dtos;

namespace TripsApp.Api.Commands
{
    public class SaveTripCommand : IRequest<bool>
    {
        public TripDto TripDto { get; set; }

        public SaveTripCommand(TripDto tripDto)
        {
            TripDto = tripDto;
        }
    }
}