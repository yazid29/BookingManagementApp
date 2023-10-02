using API.Contracts;
using API.Data;
using BookingManagementApp.Models;
using System;
using System.Data;

namespace API.Repositories
{
    public class AccountRoleRepos : GeneralRepos<AccountRole>, IAccountRoleRepository
    {
        public AccountRoleRepos(BookingManagementDBContext context) : base(context) { }
    }
}
