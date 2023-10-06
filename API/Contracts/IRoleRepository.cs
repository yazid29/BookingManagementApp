using BookingManagementApp.Models;

namespace API.Contracts
{
    public interface IRoleRepository : IGeneralRepos<Role>
    {
        public Guid? GetDefaultRoleGuid();
        public Guid? GetRoleGuid(string name);
        /*
        IEnumerable<Role> GetAll();
        Role? GetByGuid(Guid guid);
        Role? Create(Role role);
        bool Update(Role role);
        bool Delete(Role role);
        */
    }
}
