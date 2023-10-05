using API.DTO.Accounts;
using FluentValidation;

namespace API.Utilities.Validator.Account
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDto>
    {
        public ForgotPasswordValidator() {
            RuleFor(e => e.Email)
                .EmailAddress().WithMessage("Format Email Salah")
                .NotEmpty().WithMessage("Email harus diisi");
        }
    }
}
