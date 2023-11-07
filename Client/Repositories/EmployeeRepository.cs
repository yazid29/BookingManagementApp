using API.DTO.Employees;
using API.Utilities.Handler;
using BookingManagementApp.Models;
using Client.Contracts;

namespace Client.Repository
{
    public class EmployeeRepository : GeneralRepository<EmployeeDto, Guid>, IEmployeeRepository
    {
        public EmployeeRepository(string request = "Employee/") : base(request)
        {

        }
    }
}
