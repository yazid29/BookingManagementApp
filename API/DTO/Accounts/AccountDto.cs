
using BookingManagementApp.Models;

namespace API.DTO.Accounts
{
    public class AccountDto : GeneralGuid
    {
        // atribut yang ingin ditampilkan dan diisi oleh User
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsUsed { get; set; }
        public static explicit operator AccountDto(Account acc)
        {
            
            return new AccountDto
            {
                Guid = acc.Guid,
                Password = acc.Password,
                IsDeleted = acc.IsDeleted,
                IsUsed = acc.IsUsed
            };
        }

        public static implicit operator Account(AccountDto accDto)
        {
            // konversi DTO ke Model University agar dapat diproses oleh Repository-Model
            return new Account
            {
                Guid = accDto.Guid,
                Password = accDto.Password,
                IsUsed = accDto.IsUsed,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
