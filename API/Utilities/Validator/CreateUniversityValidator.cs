using API.DTO.Universities;
using FluentValidation;

namespace API.Utilities.Validator
{
    public class CreateUniversityValidator : AbstractValidator<CreateUniversityDto>
    {
        // add rule validation setiap field input
        // setiap field memiliki validation yang berbeda
        public CreateUniversityValidator()
        {
            RuleFor(e => e.Code)
               .NotEmpty().WithMessage("Code University harus diisi.")
               .MaximumLength(50).WithMessage("Code University tidak dapat menampung lebih dari 50 karakter");

            RuleFor(e => e.Name)
               .NotEmpty().WithMessage("Name University harus diisi.")
               .Matches("^[a-zA-Z\\s]*$").WithMessage("Name University hanya boleh berisi huruf dan spasi.")
               .MaximumLength(100).WithMessage("Name University tidak dapat menampung lebih dari 100 karakter");
        }
    }
}
