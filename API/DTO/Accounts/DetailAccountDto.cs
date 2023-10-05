using API.DTO.Employees;
using BookingManagementApp.Models;

namespace API.DTO.Accounts
{
    public class DetailAccountDto
    {
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsUsed { get; set; }
        public string Password { get; set; }
        public int Otp { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string Nik { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static implicit operator Account(DetailAccountDto account)
        {
            // konversi DTO ke Model University agar dapat diproses oleh Repository-Model
            return new Account
            {
                Guid = account.Guid,
                Password = account.Password,
                Otp = account.Otp,
                IsDeleted = account.IsDeleted,
                IsUsed = account.IsUsed,
                ExpiredDate = account.ExpiredDate
            };
        }
    }
}
