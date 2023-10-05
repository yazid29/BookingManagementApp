using BookingManagementApp.Models;

namespace API.DTO.Roles
{
    public class CreateRolesDto
    {
        public string Name { get; set; }
        public static implicit operator Role(CreateRolesDto CreateDto)
        {
            // setelah method dipanggil akan otomatis konversi isi atribut
            // konversi DTO ke Model University agar dapat di Insert oleh Repository-Model
            return new Role
            {
                Guid = Guid.NewGuid(),
                Name = CreateDto.Name,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
