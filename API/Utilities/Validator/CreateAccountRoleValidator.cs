using API.DTO.AccountRoles;
using FluentValidation;

namespace API.Utilities.Validator
{
    public class CreateAccountRoleValidator : AbstractValidator<CreateAccountRolesDto>
    {
        // add rule validation setiap field input
        // setiap field memiliki validation yang berbeda
        public CreateAccountRoleValidator() {
            RuleFor(e => e.AccountGuid)
                .NotEmpty().WithMessage("Major harus diisi");

            RuleFor(e => e.RoleGuid)
                .NotEmpty().WithMessage("Major harus diisi");
        }
    }
}
