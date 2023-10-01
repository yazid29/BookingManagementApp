using BookingManagementApp.Models;

namespace API.Contracts
{
    public interface IAccountRoleRepository
    {
        IEnumerable<AccountRole> GetAll();
        AccountRole? GetByGuid(Guid guid);
        AccountRole? Create(AccountRole acRole);
        bool Update(AccountRole acRole);
        bool Delete(AccountRole acRole);
    }
}
