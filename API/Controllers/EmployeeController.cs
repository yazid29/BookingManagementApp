using API.Contracts;
using API.DTO.Employees;
using BookingManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository) { 
            _employeeRepository = employeeRepository;
        }
        // kirimkan data untuk diInsert ke Database dengan metode POST
        [HttpPost]
        public IActionResult Create(CreateEmployeeDto employeeDto)
        {
            var result = _employeeRepository.Create(employeeDto);
            if (result is null)
            {
                return BadRequest("Failed to Create data");
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok((EmployeeDto) result);
        }
        // tampilkan semua data dengan metode GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _employeeRepository.GetAll();
            if (!result.Any())
            {
                return BadRequest("Data not Found");
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            var data = result.Select(item => (EmployeeDto) item);
            return Ok(data);
        }
        // tampilkan data sesuai ID dengan metode GET
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _employeeRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok((EmployeeDto)result);
        }
        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(EmployeeDto employeeDto)
        {
            var entity = _employeeRepository.GetByGuid(employeeDto.Guid);
            if (entity is null)
            {
                return NotFound("Id Not Found");
            }

            Employee toUpdate = employeeDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            var result = _employeeRepository.Update(toUpdate);
            if (!result)
            {
                return BadRequest("Failed to update data");
            }

            return Ok("Data Updated");
        }
        // Delete data sesuai ID dengan metode DELETE
        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var result = _employeeRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            var delete = _employeeRepository.Delete(result);
            if (delete is false)
            {
                return BadRequest("Failed to Delete data");
            }
            return Ok(delete);
        }
    }
}
