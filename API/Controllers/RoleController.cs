using API.Contracts;
using BookingManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository) { 
            _roleRepository = roleRepository;
        }
        // kirimkan data untuk diInsert ke Database dengan metode POST
        [HttpPost]
        public IActionResult Create(Role role)
        {
            var result = _roleRepository.Create(role);
            if (result is null)
            {
                return BadRequest("Failed to Create data");
            }

            return Ok(result);
        }
        // tampilkan semua data dengan metode GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _roleRepository.GetAll();
            if (!result.Any())
            {
                return BadRequest("Data not Found");
            }

            return Ok(result);
        }
        // tampilkan data sesuai ID dengan metode GET
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _roleRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            return Ok(result);
        }
        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(Role role)
        {
            var resultUpdate = _roleRepository.Update(role);
            if (resultUpdate is false)
            {
                return BadRequest("Failed to Update data");
            }
            return Ok(resultUpdate);
        }
        // Delete data sesuai ID dengan metode DELETE
        [HttpDelete("{guid}")]
        public IActionResult Delete(Guid guid)
        {
            var result = _roleRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            var delete = _roleRepository.Delete(result);
            if (delete is false)
            {
                return BadRequest("Failed to Delete data");
            }
            return Ok(delete);
        }
    }
}
