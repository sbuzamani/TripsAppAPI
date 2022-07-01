using FluentValidation;
using TripsApp.Api.Requests;

namespace TripsApp.Api.Validators
{
    public class TripSummaryRequestValidator : AbstractValidator<TripSummaryRequest>
    {
        public TripSummaryRequestValidator()
        {

            RuleFor(c => c.VehicleId)
                .NotEmpty()
                .WithMessage("VehicleId cannot be empty");

            RuleFor(m => m.StartDate)
                .NotEmpty()
                .WithMessage("Start Date is Required");

            RuleFor(m => m.EndDate)
                .NotEmpty()
                .WithMessage("End date is required")
                .GreaterThan(m => m.StartDate)
                .WithMessage("End date must be later than Start date");
        }
    }
}
