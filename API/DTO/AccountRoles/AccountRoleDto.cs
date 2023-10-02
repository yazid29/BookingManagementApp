
using BookingManagementApp.Models;

namespace API.DTO.AccountRoles
{
    public class AccountRoleDto : GeneralGuid
    {
        public Guid AccountGuid { get; set; }
        public Guid RoleGuid { get; set; }
        public static explicit operator AccountRoleDto(AccountRole accRole)
        {
            return new AccountRoleDto
            {
                Guid = accRole.Guid,
                AccountGuid = accRole.AccountGuid,
                RoleGuid = accRole.RoleGuid
            };
        }

        public static implicit operator AccountRole(AccountRoleDto accRoleDto)
        {
            return new AccountRole
            {
                Guid = accRoleDto.Guid,
                AccountGuid = accRoleDto.AccountGuid,
                RoleGuid = accRoleDto.RoleGuid,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
