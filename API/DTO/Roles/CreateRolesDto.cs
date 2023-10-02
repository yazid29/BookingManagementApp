using API.DTO.Rooms;
using BookingManagementApp.Models;

namespace API.DTO.Roles
{
    public class CreateRolesDto
    {
        public string Name { get; set; }
        public static implicit operator Role(CreateRolesDto CreateDto)
        {
            return new Role
            {
                Name = CreateDto.Name,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
