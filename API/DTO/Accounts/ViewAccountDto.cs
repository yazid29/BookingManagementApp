using BookingManagementApp.Models;

namespace API.DTO.Accounts
{
    public class ViewAccountDto : GeneralGuid
    {
        public bool IsDeleted { get; set; }
        public bool IsUsed { get; set; }
        public string Password { get; set; }
        public int Otp { get; set; }
        public static explicit operator ViewAccountDto(Account acc)
        {
            return new ViewAccountDto
            {
                Guid = acc.Guid,
                Password = acc.Password,
                Otp = acc.Otp,
                IsDeleted = acc.IsDeleted,
                IsUsed = acc.IsUsed
            };
        }
    }
}
