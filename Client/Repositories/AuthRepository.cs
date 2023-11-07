using API.DTO.Accounts;
using API.DTO.Employees;
using API.Utilities.Handler;
using Azure.Core;
using BookingManagementApp.Models;
using Client.Contracts;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Client.Repository
{
    public class AuthRepository : GeneralRepository<EmployeeDto, Guid>, IEmployeeRepository
    {
        public AuthRepository(string request = "Auth/") : base(request)
        {

        }
        
    }
}
