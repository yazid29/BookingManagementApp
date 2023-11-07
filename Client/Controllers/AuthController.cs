using API.DTO.Accounts;
using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AuthController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }


        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await _accountRepository.Login(login);

            if (result.Status == "OK")
            {

                HttpContext.Session.SetString("JWToken", result.Data.Token);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet("Logout/")]
        [Authorize]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "Home");
        }
        [HttpGet("account/getclaims/")]
        public async Task<JsonResult> GetToken()
        {
            var a = "aaaa";
            return Json(a);
        }
    }
}