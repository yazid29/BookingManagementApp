using API.Contracts;
using API.Data;
using BookingManagementApp.Models;

namespace API.Repositories
{
    public class RoleRepos : GeneralRepos<Role>, IRoleRepository
    {
        public RoleRepos(BookingManagementDBContext context) : base(context) { }
    }
}
