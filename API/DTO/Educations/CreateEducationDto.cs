using API.DTO.Rooms;
using BookingManagementApp.Models;

namespace API.DTO.Educations
{
    public class CreateEducationDto 
    {
        public string Major { get; set; }
        public string Degree { get; set; }
        public float Gpa { get; set; }
        public Guid UniversityGuid { get; set; }

        public static implicit operator Education(CreateEducationDto CreateDto)
        {
            return new Education
            {
                Major = CreateDto.Major,
                Degree = CreateDto.Degree,
                Gpa = CreateDto.Gpa,
                UniversityGuid = CreateDto.UniversityGuid,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
