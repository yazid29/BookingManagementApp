using API.DTO.Roles;
using FluentValidation;

namespace API.Utilities.Validator.Role
{
    public class UpdateRoleValidator : AbstractValidator<RoleDto>
    {
        // add rule validation setiap field input
        // setiap field memiliki validation yang berbeda
        public UpdateRoleValidator()
        {
            RuleFor(e => e.Guid)
               .NotEmpty().WithMessage("Guid harus diisi");

            RuleFor(e => e.Name)
               .NotEmpty().WithMessage("NameRole harus diisi.")
               .MaximumLength(100).WithMessage("NameRole tidak dapat menampung lebih dari 100 karakter")
               .Matches("^[a-zA-Z\\s]*$").WithMessage("FirstName hanya boleh berisi huruf dan spasi");
        }
    }
}
