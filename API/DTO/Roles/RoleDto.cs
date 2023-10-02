using BookingManagementApp.Models;

namespace API.DTO.Roles
{
    public class RoleDto : GeneralGuid
    {
        // atribut yang ingin ditampilkan ke User
        public string Name { get; set; }
        public static explicit operator RoleDto(Role role)
        {
            // atribut yang ingin ditampilkan dan diisi oleh User
            return new RoleDto
            {
                Guid = role.Guid,
                Name = role.Name
            };
        }

        public static implicit operator Role(RoleDto roleDto)
        {
            // konversi DTO ke Model University agar dapat diproses oleh Repository-Model
            return new Role
            {
                Guid = roleDto.Guid,
                Name = roleDto.Name,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
