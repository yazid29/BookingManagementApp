using API.DTO.Universities;
using FluentValidation;

namespace API.Utilities.Validator
{
    public class CreateUniversityValidator : AbstractValidator<CreateUniversityDto>
    {
        
        public CreateUniversityValidator()
        {
            RuleFor(e => e.Code)
               .NotEmpty().WithMessage("Code University harus diisi.")
               .MaximumLength(50).WithMessage("Code University tidak dapat menampung lebih dari 50 karakter");

            RuleFor(e => e.Name)
               .NotEmpty().WithMessage("Name harus diisi.")
               .Matches("^[a-zA-Z\\s]*$").WithMessage("Name hanya boleh berisi huruf dan spasi.")
               .MaximumLength(100).WithMessage("Name tidak dapat menampung lebih dari 100 karakter");
        }
    }
}
