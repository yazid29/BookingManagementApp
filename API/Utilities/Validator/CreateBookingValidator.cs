using API.DTO.Bookings;
using API.Utilities.Enums;
using FluentValidation;

namespace API.Utilities.Validator
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingDto>
    {
        // add rule validation setiap field input
        // setiap field memiliki validation yang berbeda
        public CreateBookingValidator() {
            RuleFor(e => e.StartDate)
               .NotEmpty().WithMessage("StartDate Booking harus diisi")
               .Must(date => date>=DateTime.Now).WithMessage("Tanggal StartDate Booking tidak valid");

            RuleFor(e => e.EndDate)
               .NotEmpty().WithMessage("EndDate Booking harus diisi")
               .GreaterThan(DateTime.Now).WithMessage("Tanggal EndDate Booking tidak valid");

            RuleFor(e => e.Status)
               .NotEmpty().WithMessage("Status Booking harus diisi")
               .IsInEnum();

            RuleFor(e => e.Remarks)
               .NotEmpty().WithMessage("Remarks Booking harus diisi");
        }
    }
}
