using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }
    }
}