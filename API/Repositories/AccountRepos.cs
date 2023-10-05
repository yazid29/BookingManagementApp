using API.Contracts;
using API.Data;
using BookingManagementApp.Models;
using System;
using System.Data;
using System.Linq;

namespace API.Repositories
{
    public class AccountRepos : GeneralRepos<Account>, IAccountRepository
    {
        public AccountRepos(BookingManagementDBContext context) : base(context) {

        }

        
    }
}
