using API.DTO.Employees;
using BookingManagementApp.Models;

namespace Client.Contracts
{
    public interface IEmployeeRepository : IRepository<EmployeeDto, Guid>
    {


    }
}
