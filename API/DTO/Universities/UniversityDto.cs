using BookingManagementApp.Models;

namespace API.DTO.Universities
{
    public class UniversityDto : GeneralGuid
    {
        // atribut yang ingin ditampilkan ke User
        public string Code { get; set; }
        public string Name { get; set; }

        public static explicit operator UniversityDto(University university)
        {
            // atribut yang ingin ditampilkan dan diisi oleh User
            return new UniversityDto
            {
                Guid = university.Guid,
                Code = university.Code,
                Name = university.Name
            };
        }

        public static implicit operator University(UniversityDto universityDto)
        {
            // konversi DTO ke Model University agar dapat diproses oleh Repository-Model
            return new University
            {
                Guid = universityDto.Guid,
                Code = universityDto.Code,
                Name = universityDto.Name,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
