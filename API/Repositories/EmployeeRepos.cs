using API.Contracts;
using API.Data;
using BookingManagementApp.Models;
using System.Data;

namespace API.Repositories
{
    public class EmployeeRepos : IEmployeeRepository
    {
        private readonly BookingManagementDBContext _context;

        public EmployeeRepos(BookingManagementDBContext context)
        {
            _context = context;
        }
        public Employee? Create(Employee employee)
        {
            try
            {
                _context.Set<Employee>().Add(employee);
                _context.SaveChanges();
                return employee;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(Employee employee)
        {
            try
            {
                _context.Set<Employee>().Remove(employee);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Set<Employee>().ToList();
        }

        public Employee? GetByGuid(Guid guid)
        {
            return _context.Set<Employee>().Find(guid);
        }

        public bool Update(Employee employee)
        {
            try
            {
                _context.Set<Employee>().Update(employee);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
