using API.Contracts;
using BookingManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class UniversityController:ControllerBase
    {
        // hubungkan repository dengan controller
        private readonly IUniversityRepository _universityRepository;

        public UniversityController(IUniversityRepository universityRepository)
        {
            _universityRepository = universityRepository;
        }

        // tampilkan semua data dengan metode GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _universityRepository.GetAll();
            if (!result.Any())
            {
                return NotFound("Data Not Found");
            }

            return Ok(result);
        }

        // tampilkan data sesuai ID dengan metode GET
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _universityRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            return Ok(result);
        }

        // kirimkan data untuk diInsert ke Database dengan metode POST
        [HttpPost]
        public IActionResult Create(University university)
        {
            var result = _universityRepository.Create(university);
            if (result is null)
            {
                return BadRequest("Failed to Create data");
            }

            return Ok(result);
        }

        // Update data sesuai ID dengan metode PUT
        [HttpPut("{guid}")]
        public IActionResult Update(University university)
        {
            var result = _universityRepository.Update(university);
            if (result is false)
            {
                return BadRequest("Failed to Update data");
            }
            return Ok(result);
        }

        // Delete data sesuai ID dengan metode DELETE
        [HttpDelete("{guid}")]
        public IActionResult Delete(University university)
        {
            var result = _universityRepository.Delete(university);
            if (result is false)
            {
                return BadRequest("Failed to Delete data");
            }
            return Ok(result);
        }
        
    }
}
