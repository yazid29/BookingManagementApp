using API.DTO.Employees;
using FluentValidation;

namespace API.Utilities.Validator.Account
{
    public class RegisterEmployeeValidator : AbstractValidator<RegisterNewEmployeeDto>
    {
        public RegisterEmployeeValidator()
        {
            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("FirstName harus diisi.")
                .Matches("^[a-zA-Z\\s]*$").WithMessage("FirstName hanya boleh berisi huruf dan spasi.")
                .MaximumLength(100).WithMessage("FirstName tidak dapat menampung lebih dari 100 karakter");

            RuleFor(e => e.LastName)
                .Matches("^[a-zA-Z\\s]*$").WithMessage("LastName hanya boleh berisi huruf dan spasi.")
                .MaximumLength(100).WithMessage("LastName tidak dapat menampung lebih dari 100 karakter");

            RuleFor(e => e.BirthDate)
                .NotEmpty().WithMessage("Tanggal lahir harus diisi.")
                .LessThanOrEqualTo(DateTime.Now.AddYears(-18)).WithMessage("Harus umur 18 tahun keatas"); // 18 years old

            RuleFor(e => e.Gender)
                .NotEmpty().WithMessage("Gender Harus Diisi")
                .IsInEnum()
                .Equals(0);

            RuleFor(e => e.HiringDate)
                .NotEmpty().WithMessage("Tanggal perekrutan harus diisi.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Tanggal perekrutan tidak valid");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Tidak Boleh Kosong")
                .EmailAddress().WithMessage("Format Email Salah")
                .MaximumLength(100).WithMessage("Nama tidak dapat menampung lebih dari 100 karakter");

            RuleFor(e => e.PhoneNumber)
                .NotEmpty().WithMessage("Tidak Boleh Kosong")
                .MinimumLength(10).WithMessage("PhoneNumber minimal 10 karakter")
                .MaximumLength(20).WithMessage("PhoneNumber Tidak dapat menampung lebih dari 20 karakter")
                .Matches("^[0-9]*$").WithMessage("PhoneNumber harus terdiri dari digit angka");
            RuleFor(e => e.UniversityCode)
               .NotEmpty().WithMessage("Guid Booking harus diisi");
            RuleFor(e => e.UniversityName)
               .NotEmpty().WithMessage("Guid Booking harus diisi");
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
        }
    }
}
