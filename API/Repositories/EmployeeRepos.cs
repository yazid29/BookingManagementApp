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

        string? IEmployeeRepository.GetLastNik()
        {
            var getlast = _contextEmp.Set<Employee>().
                OrderBy(nik => nik.Nik).LastOrDefault()?.Nik;
            return getlast;
        }
        string? IEmployeeRepository.GetEmail(string email)
        {
            var emailEmp = _contextEmp.Set<Employee>().FirstOrDefault(q => (q.Email == email))?.Email;
            return emailEmp;
        }

        public Employee? GetGuidByEmail(string email)
        {
            var emailEmp = _contextEmp.Set<Employee>()
                .Where(q => (q.Email == email)).FirstOrDefault();
            return emailEmp;
        }
    }
}
