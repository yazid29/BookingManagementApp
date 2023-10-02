
using API.DTO.Roles;
using BookingManagementApp.Models;

namespace API.DTO.Accounts
{
    public class AccountDto : GeneralGuid
    {
        public bool IsDeleted { get; set; }
        public bool IsUsed { get; set; }
        public static explicit operator AccountDto(Account acc)
        {
            return new AccountDto
            {
                Guid = acc.Guid,
                IsDeleted = acc.IsDeleted,
                IsUsed = acc.IsUsed
            };
        }

        public static implicit operator Account(AccountDto accDto)
        {
            return new Account
            {
                Guid = accDto.Guid,
                IsDeleted = accDto.IsDeleted,
                IsUsed = accDto.IsUsed,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
