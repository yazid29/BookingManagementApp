using API.Contracts;
using API.Data;
using BookingManagementApp.Models;

namespace API.Repositories
{
    public class RoleRepos : IRoleRepository
    {
        private readonly BookingManagementDBContext _context;

        public RoleRepos(BookingManagementDBContext context)
        {
            _context = context;
        }
        Role? IRoleRepository.Create(Role role)
        {
            try
            {
                _context.Set<Role>().Add(role);
                _context.SaveChanges();
                return role;
            }
            catch
            {
                return null;
            }
        }

        bool IRoleRepository.Delete(Role role)
        {
            try
            {
                _context.Set<Role>().Remove(role);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        IEnumerable<Role> IRoleRepository.GetAll()
        {
            return _context.Set<Role>().ToList();
        }

        Role? IRoleRepository.GetByGuid(Guid guid)
        {
            return _context.Set<Role>().Find(guid);
        }

        bool IRoleRepository.Update(Role role)
        {
            try
            {
                _context.Set<Role>().Update(role);
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
