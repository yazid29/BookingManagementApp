using BookingManagementApp.Models;

namespace API.Contracts
{
    public interface IEmployeeRepository : IGeneralRepos<Employee>
    {
        string? GetLastNik();
        /*
        IEnumerable<Employee> GetAll();
        Employee? GetByGuid(Guid guid);
        Employee? Create(Employee employee);
        bool Update(Employee employee);
        bool Delete(Employee employee);
        */
    }
}
