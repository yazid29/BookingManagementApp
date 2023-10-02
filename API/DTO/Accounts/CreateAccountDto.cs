using API.DTO.Rooms;
using BookingManagementApp.Models;

namespace API.DTO.Accounts
{
    public class CreateAccountDto 
    {
        public string Password { get; set; }
        //public bool IsDeleted { get; set; }
        //public int Otp { get; set; }
        //public bool IsUsed { get; set; }
        public DateTime ExpiredDate { get; set; }
        public static implicit operator Account(CreateAccountDto CreateDto)
        {
            return new Account
            {
                Password = CreateDto.Password,
                IsDeleted = false,
                Otp = 1,
                IsUsed = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
