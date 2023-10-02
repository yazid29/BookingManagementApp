using API.DTO.Universities;
using BookingManagementApp.Models;

namespace API.DTO.AccountRoles
{
    public class CreateAccountRolesDto 
    {
        public Guid AccountGuid { get; set; }
        public Guid RoleGuid { get; set; }
        public static implicit operator AccountRole(CreateAccountRolesDto CreateDto)
        {
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
