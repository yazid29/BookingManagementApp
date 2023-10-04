using API.DTO.Bookings;
using API.Utilities.Enums;
using FluentValidation;

namespace API.Utilities.Validator.Booking
{
    public class UpdateBookingValidator : AbstractValidator<BookingDto>
    {
        // add rule validation setiap field input
        // setiap field memiliki validation yang berbeda
        public UpdateBookingValidator()
        {

            RuleFor(e => e.Guid)
               .NotEmpty().WithMessage("Guid Booking harus diisi");

            RuleFor(e => e.StartDate)
               .NotEmpty().WithMessage("StartDate Booking harus diisi")
               .Must(date => date >= DateTime.Now).WithMessage("Tanggal StartDate Booking tidak valid");

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
