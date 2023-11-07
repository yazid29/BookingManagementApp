using API.DTO.Employees;
using API.DTO.Universities;
using BookingManagementApp.Models;
using Client.Contracts;
using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace Client.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var result = await repository.Get();
            var listEmployee = new List<EmployeeDto>();
            if (result != null)
            {
                listEmployee = result.Data.ToList();
            }

            return View(listEmployee);
        }
        public async Task<JsonResult> GetAllEmployee()
        {
            var result = await repository.Get();
            return Json(result.Data);
        }
        public async Task<IActionResult> CreateView()
        {
            return View();
        }

        public async Task<IActionResult> CreateEmployee(EmployeeDto employeeDto)
        {
            var result = await repository.Post(employeeDto);
            if (result != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                var result = await repository.Put(employeeDto.Guid, employeeDto);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var cek = id.GetType();
            EmployeeDto dataEmp = new EmployeeDto();
            var result = await repository.Get(id);
            if (result != null)
            {
                dataEmp = result.Data;
            }
            return View(dataEmp);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var cek = id.GetType();
            EmployeeDto dataEmp = new EmployeeDto();
            var result = await repository.Get(id);
            if (result != null)
            {
                dataEmp = result.Data;
            }
            return View(dataEmp);
        }
        public async Task<IActionResult> DeleteId(Guid id)
        {
            var result = await repository.Get(id);
            var dataEmp = new EmployeeDto();
            if (result.Data?.Guid != null)
            {
                return View(result.Data); 
            }
            else
            {
                return View(dataEmp);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Remove(Guid Guid)
        {
            var result = await repository.Delete(Guid);
            var dataEmp = new EmployeeDto();
            if (result.Data?.Guid != null)
            {
                return View(result.Data);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            
        }
        
    }
}