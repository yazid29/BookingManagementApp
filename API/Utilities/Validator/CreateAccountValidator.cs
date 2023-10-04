using API.DTO.Accounts;
using FluentValidation;

namespace API.Utilities.Validator
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountDto>
    {
        public CreateAccountValidator() {
            RuleFor(e => e.Guid)
               .NotEmpty().WithMessage("Guid Booking harus diisi");

            RuleFor(e => e.Password)
               .NotEmpty().WithMessage("Password Booking harus diisi")
               .MinimumLength(6).WithMessage("Password minimal 6 karakter")
               .Matches(@"^(?=.*[a-zA-Z])(?=.*\d).*$")
               .WithMessage("Password minimal memiliki kombinasi huruf dan angka");
        }
    }
}
