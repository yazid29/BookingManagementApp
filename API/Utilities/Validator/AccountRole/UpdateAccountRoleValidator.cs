using API.DTO.AccountRoles;
using FluentValidation;

namespace API.Utilities.Validator.AccountRole
{
    public class UpdateAccountRoleValidator : AbstractValidator<AccountRoleDto>
    {
        // add rule validation setiap field input
        // setiap field memiliki validation yang berbeda
        public UpdateAccountRoleValidator()
        {
            RuleFor(e => e.Guid)
                .NotEmpty().WithMessage("Guid harus diisi");

            RuleFor(e => e.AccountGuid)
                .NotEmpty().WithMessage("AccountGuid harus diisi");

            RuleFor(e => e.RoleGuid)
                .NotEmpty().WithMessage("RoleGuid harus diisi");
        }
    }
}
