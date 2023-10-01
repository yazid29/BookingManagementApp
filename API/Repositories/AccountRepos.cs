using API.Contracts;
using API.Data;
using BookingManagementApp.Models;
using System;
using System.Data;

namespace API.Repositories
{
    public class AccountRepos : IAccountRepository
    {
        private readonly BookingManagementDBContext _context;

        public AccountRepos(BookingManagementDBContext context)
        {
            _context = context;
        }

        Account? IAccountRepository.Create(Account account)
        {
            try
            {
                _context.Set<Account>().Add(account);
                _context.SaveChanges();
                return account;
            }
            catch
            {
                return null;
            }
        }

        bool IAccountRepository.Delete(Account account)
        {
            try
            {
                _context.Set<Account>().Remove(account);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        IEnumerable<Account> IAccountRepository.GetAll()
        {
            return _context.Set<Account>().ToList();
        }

        Account? IAccountRepository.GetByGuid(Guid guid)
        {
            return _context.Set<Account>().Find(guid);
        }

        bool IAccountRepository.Update(Account account)
        {
            try
            {
                _context.Set<Account>().Update(account);
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
