using API.Contracts;
using API.Data;
using BookingManagementApp.Models;

namespace API.Repositories
{
    public class RoleRepos : GeneralRepos<Role>, IRoleRepository
    {
        private readonly BookingManagementDBContext _contextRole;
        public RoleRepos(BookingManagementDBContext context) : base(context) {
            _contextRole = context;
        }

        public Guid? GetDefaultRoleGuid()
        {
            var cekGuid = _contextRole.Set<Role>()
                .FirstOrDefault(e => e.Name == "User")?.Guid;
            return cekGuid;
        }

        public Guid? GetRoleGuid(string name)
        {
            var cekGuid = _contextRole.Set<Role>()
                .FirstOrDefault(e => e.Name == name)?.Guid;
            return cekGuid;
        }
    }
}
