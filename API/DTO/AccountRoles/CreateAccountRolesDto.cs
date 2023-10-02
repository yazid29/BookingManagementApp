using BookingManagementApp.Models;

namespace API.DTO.AccountRoles
{
    public class CreateAccountRolesDto 
    {
        public Guid AccountGuid { get; set; }
        public Guid RoleGuid { get; set; }

        public static implicit operator AccountRole(CreateAccountRolesDto CreateDto)
        {
            // setelah method dipanggil akan otomatis konversi isi atribut
            // konversi DTO ke Model University agar dapat di Insert oleh Repository-Model
            return new AccountRole
            {
                AccountGuid = CreateDto.AccountGuid,
                RoleGuid = CreateDto.RoleGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
