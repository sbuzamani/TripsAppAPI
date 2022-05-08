using FluentValidation;
using TripsApp.ApplicationServices.Dtos;

namespace TripsApp.Api.Validators
{
    public class SaveTripValidator : AbstractValidator<TripDto>
    {
        public SaveTripValidator()
        {
            RuleFor(c => c.VehicleId)
                .NotEmpty()
                .WithMessage("VehicleId cannot be empty");

            RuleFor(c => c.Distance)
                .NotEmpty()
                .WithMessage("Distance cannot be empty");

            RuleFor(c => c.CountryId)
                .NotEmpty()
                .WithMessage("CountryId cannot be empty");

            RuleFor(c => c.TimeStamp)
                .NotEmpty()
                .WithMessage("Timestamp cannot be empty");
        }
    }
}
