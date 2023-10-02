using BookingManagementApp.Models;

namespace API.DTO.Accounts
{
    public class CreateAccountDto : GeneralGuid
    {
        public string Password { get; set; }
        public static implicit operator Account(CreateAccountDto CreateDto)
        {
            // setelah method dipanggil akan otomatis konversi isi atribut
            // konversi DTO ke Model University agar dapat di Insert oleh Repository-Model
            return new Account
            {
                Guid = CreateDto.Guid,
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
