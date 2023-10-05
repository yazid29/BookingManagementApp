using API.DTO.Accounts;
using FluentValidation;

namespace API.Utilities.Validator.Account
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordValidator()
        {
            RuleFor(e => e.Email)
               .NotEmpty().WithMessage("Email harus diisi");
        }
    }
}
