using API.DTO.Accounts;
using FluentValidation;

namespace API.Utilities.Validator.Account
{
    public class UpdateAccountValidator : AbstractValidator<AccountDto>
    {
        // add rule validation setiap field input
        // setiap field memiliki validation yang berbeda
        public UpdateAccountValidator()
        {
            RuleFor(e => e.Guid)
               .NotEmpty().WithMessage("Guid Booking harus diisi");

            RuleFor(e => e.Password)
               .NotEmpty().WithMessage("Password Booking harus diisi")
               .MinimumLength(6).WithMessage("Password minimal 6 karakter")
               .Matches(@"^(?=.*[a-zA-Z])(?=.*\d).*$")
               .WithMessage("Password minimal memiliki kombinasi huruf dan angka");

            RuleFor(e => e.IsDeleted)
               .NotEmpty().WithMessage("IsDeleted Booking harus diisi");

            RuleFor(e => e.IsUsed)
               .NotEmpty().WithMessage("IsUsed Booking harus diisi");
        }
    }
}
