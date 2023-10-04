using API.DTO.Educations;
using FluentValidation;

namespace API.Utilities.Validator.Education
{
    public class CreateEducationValidator : AbstractValidator<CreateEducationDto>
    {
        // add rule validation setiap field input
        // setiap field memiliki validation yang berbeda
        public CreateEducationValidator()
        {
            RuleFor(e => e.Guid)
               .NotEmpty().WithMessage("Guid harus diisi");
            RuleFor(e => e.Major)
               .NotEmpty().WithMessage("Major harus diisi.")
               .MaximumLength(100).WithMessage("Major tidak dapat menampung lebih dari 100")
               .Matches("^[a-zA-Z\\s]*$").WithMessage("Major hanya boleh berisi huruf dan spasi");
            RuleFor(e => e.Degree)
               .NotEmpty().WithMessage("Degree harus diisi.")
               .MaximumLength(100).WithMessage("Degree tidak dapat menampung lebih dari 100")
               .Matches("^[a-zA-Z\\s]*$").WithMessage("Degree hanya boleh berisi huruf dan spasi");
            RuleFor(e => e.Gpa)
               .NotEmpty().WithMessage("Major harus diisi.")
               .InclusiveBetween(0, 4).WithMessage("GPA harus berada di antara 0 dan 4");
            RuleFor(e => e.UniversityGuid)
               .NotEmpty().WithMessage("Major harus diisi");
        }
    }
}
