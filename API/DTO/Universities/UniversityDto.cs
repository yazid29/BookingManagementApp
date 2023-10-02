using BookingManagementApp.Models;

namespace API.DTO.Universities
{
    public class UniversityDto : GeneralGuid
    {
        //public System.Guid Guid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public static explicit operator UniversityDto(University university)
        {
            return new UniversityDto
            {
                Guid = university.Guid,
                Code = university.Code,
                Name = university.Name
            };
        }

        public static implicit operator University(UniversityDto universityDto)
        {
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
