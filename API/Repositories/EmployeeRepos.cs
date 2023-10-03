using API.Contracts;
using API.Data;
using BookingManagementApp.Models;
using System;
using System.Data;

namespace API.Repositories
{
    public class EmployeeRepos : GeneralRepos<Employee>, IEmployeeRepository
    {
        private readonly BookingManagementDBContext _contextEmp;
        public EmployeeRepos(BookingManagementDBContext context) : base(context) {
            _contextEmp = context;
        }

        Employee IEmployeeRepository.GetLastNik()
        {
            var getlast = _contextEmp.Set<Employee>().
                OrderBy(nik => nik.Nik).Last();
            _contextEmp.ChangeTracker.Clear();
            return getlast;
        }
    }
}
