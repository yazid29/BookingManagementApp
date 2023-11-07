using API.DTO.Employees;
using API.DTO.Universities;
using API.Utilities.Handler;
using BookingManagementApp.Models;
using Client.Contracts;

namespace Client.Repository
{
    public class UniversityRepository : GeneralRepository<UniversityDto, Guid>, IUniversityRepository
    {
        public UniversityRepository(string request = "University/") : base(request)
        {

        }
    }
}
