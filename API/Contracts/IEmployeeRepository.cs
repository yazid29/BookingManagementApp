using BookingManagementApp.Models;

namespace API.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee? GetByGuid(Guid guid);
        Employee? Create(Employee employee);
        bool Update(Employee employee);
        bool Delete(Employee employee);
    }
}
