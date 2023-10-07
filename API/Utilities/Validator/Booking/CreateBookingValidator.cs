using API.DTO.Bookings;
using API.Utilities.Enums;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API.Utilities.Validator.Booking
{
    public class CreateBookingValidator : AbstractValidator<CreateBookingDto>
    {
        // add rule validation setiap field input
        // setiap field memiliki validation yang berbeda
        public CreateBookingValidator()
        {
            RuleFor(e => e.StartDate)
            .NotEmpty().WithMessage("StartDate Booking harus diisi")
               .Must(date => date >= DateTime.Now.Date).WithMessage("Tanggal StartDate Booking tidak valid");

            RuleFor(e => e.EndDate)
               .NotEmpty().WithMessage("EndDate Booking harus diisi")
               .GreaterThan(DateTime.Now).WithMessage("Tanggal EndDate Booking tidak valid");

            RuleFor(e => e.Remarks)
               .NotEmpty().WithMessage("Remarks Booking harus diisi");

            RuleFor(e => e.RoomGuid)
               .NotEmpty().WithMessage("Guid Room harus diisi");

            RuleFor(e => e.EmployeeGuid)
               .NotEmpty().WithMessage("Guid Employee harus diisi");
        }
    }
}
