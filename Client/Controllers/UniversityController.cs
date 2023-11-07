using API.DTO.Employees;
using API.DTO.Universities;
using BookingManagementApp.Models;
using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class UniversityController : Controller
    {
        private readonly IUniversityRepository repository;

        public UniversityController(IUniversityRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetAll()
        {
            var result = await repository.Get();
            var listEmployee = new List<UniversityDto>();
            if (result != null)
            {
                listEmployee = result.Data.ToList();
            }
            return Json(listEmployee);
        }
    }
}