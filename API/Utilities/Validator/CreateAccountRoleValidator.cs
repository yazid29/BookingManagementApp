using API.DTO.AccountRoles;
using FluentValidation;

namespace API.Utilities.Validator
{
    public class CreateAccountRoleValidator : AbstractValidator<CreateAccountRolesDto>
    {
        public CreateAccountRoleValidator() {
            RuleFor(e => e.AccountGuid)
                .NotEmpty().WithMessage("Major harus diisi");

            RuleFor(e => e.RoleGuid)
                .NotEmpty().WithMessage("Major harus diisi");
        }
    }
}
