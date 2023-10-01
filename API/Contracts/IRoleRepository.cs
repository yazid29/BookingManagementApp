using BookingManagementApp.Models;

namespace API.Contracts
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
        Role? GetByGuid(Guid guid);
        Role? Create(Role role);
        bool Update(Role role);
        bool Delete(Role role);
    }
}
