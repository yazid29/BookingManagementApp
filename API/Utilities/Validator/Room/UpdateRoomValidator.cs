using API.DTO.Rooms;
using FluentValidation;

namespace API.Utilities.Validator.Room
{
    public class UpdateRoomValidator : AbstractValidator<RoomDto>
    {
        // add rule validation setiap field input
        // setiap field memiliki validation yang berbeda
        public UpdateRoomValidator()
        {
            RuleFor(e => e.Guid)
               .NotEmpty().WithMessage("Guid harus diisi");
            RuleFor(e => e.Name)
               .NotEmpty().WithMessage("NameRoom harus diisi.")
               .MaximumLength(100).WithMessage("NameRoom tidak dapat menampung lebih dari 100 karakter");

            RuleFor(e => e.Floor)
               .NotEmpty().WithMessage("Floor harus diisi.")
               .GreaterThanOrEqualTo(1).WithMessage("Floor Harus lebih dari 1 ")
               .LessThanOrEqualTo(50).WithMessage("Floor Tidak lebih dari 50 ");

            RuleFor(e => e.Capacity)
               .NotEmpty().WithMessage("Capacity harus diisi.")
               .GreaterThanOrEqualTo(5).WithMessage("Capacity Harus lebih dari 5");
        }
    }
}
