using API.Contracts;
using API.Data;
using BookingManagementApp.Models;
using System;
using System.Data;

namespace API.Repositories
{
    public class AccountRoleRepos : IAccountRoleRepository
    {
        private readonly BookingManagementDBContext _context;

        public AccountRoleRepos(BookingManagementDBContext context)
        {
            _context = context;
        }
        AccountRole? IAccountRoleRepository.Create(AccountRole acRole)
        {
            try
            {
                _context.Set<AccountRole>().Add(acRole);
                _context.SaveChanges();
                return acRole;
            }
            catch
            {
                return null;
            }
        }

        bool IAccountRoleRepository.Delete(AccountRole acRole)
        {
            try
            {
                _context.Set<AccountRole>().Remove(acRole);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        IEnumerable<AccountRole> IAccountRoleRepository.GetAll()
        {
            return _context.Set<AccountRole>().ToList();
        }

        AccountRole? IAccountRoleRepository.GetByGuid(Guid guid)
        {
            return _context.Set<AccountRole>().Find(guid);
        }

        bool IAccountRoleRepository.Update(AccountRole acRole)
        {
            try
            {
                _context.Set<AccountRole>().Update(acRole);
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
