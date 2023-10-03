using BookingManagementApp.Models;

namespace API.DTO.Universities
{
    public class CreateUniversityDto
    {
        // atribut yang harus diisi oleh user
        public string Code { get; set; }
        public string Name { get; set; }
        
        public static implicit operator University(CreateUniversityDto createUniversityDto)
        {
            // setelah method dipanggil akan otomatis konversi isi atribut
            // konversi DTO ke Model University agar dapat di Insert oleh Repository-Model
            return new University
            {
                Guid = new Guid(),
                Code = createUniversityDto.Code,
                Name = createUniversityDto.Name,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
