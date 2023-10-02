using API.DTO.Rooms;
using BookingManagementApp.Models;

namespace API.DTO.Roles
{
    public class RoleDto : GeneralGuid
    {
        public string Name { get; set; }
        public static explicit operator RoleDto(Role role)
        {
            return new RoleDto
            {
                Guid = role.Guid,
                Name = role.Name
            };
        }

        public static implicit operator Role(RoleDto roleDto)
        {
            return new Role
            {
                Guid = roleDto.Guid,
                Name = roleDto.Name,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
