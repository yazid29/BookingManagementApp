using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class AccountController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }
    }
}