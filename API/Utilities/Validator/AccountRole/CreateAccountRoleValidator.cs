using API.DTO.AccountRoles;
using FluentValidation;

namespace API.Utilities.Validator.AccountRole
{
    public class CreateAccountRoleValidator : AbstractValidator<CreateAccountRolesDto>
    {
        // add rule validation setiap field input
        // setiap field memiliki validation yang berbeda
        public CreateAccountRoleValidator()
        {
            RuleFor(e => e.AccountGuid)
                .NotEmpty().WithMessage("AccountGuid harus diisi");

            RuleFor(e => e.RoleGuid)
                .NotEmpty().WithMessage("RoleGuid harus diisi");
        }
    }
}
