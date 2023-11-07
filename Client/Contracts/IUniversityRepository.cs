using API.DTO.Employees;
using API.DTO.Universities;
using BookingManagementApp.Models;

namespace Client.Contracts
{
    public interface IUniversityRepository : IRepository<UniversityDto, Guid>
    {


    }
}
