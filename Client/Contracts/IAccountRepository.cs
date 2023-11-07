using API.DTO.Accounts;
using API.DTO.Employees;
using API.Utilities.Handler;
using BookingManagementApp.Models;
using Client.Models;

namespace Client.Contracts
{
    public interface IAccountRepository : IRepository<AccountDto, Guid>
    {
        Task<ResponseOKHandler<TokenDto>> Login(LoginDto login);
        Task<ResponseOKHandler<TokenDto>> GetToken(string token);
    }
}
