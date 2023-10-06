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
            RuleFor(e => e.IsUsed)
               .NotEmpty().WithMessage("IsUsed Booking harus diisi");
        }
    }
}
