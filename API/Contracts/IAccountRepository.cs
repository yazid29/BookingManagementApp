using BookingManagementApp.Models;

namespace API.Contracts
{
    public interface IAccountRepository : IGeneralRepos<Account>
    {
        
        /*
        IEnumerable<Account> GetAll();
        Account? GetByGuid(Guid guid);
        Account? Create(Account account);
        bool Update(Account account);
        bool Delete(Account account);
        */
    }
}
