using API.Contracts;
using API.Data;
using BookingManagementApp.Models;
using System.Data;

namespace API.Repositories
{
    public class EmployeeRepos : GeneralRepos<Employee>, IEmployeeRepository
    {
        public EmployeeRepos(BookingManagementDBContext context) : base(context) { }
    }
}
