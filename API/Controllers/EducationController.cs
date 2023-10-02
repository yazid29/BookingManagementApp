using API.Contracts;
using API.DTO.Educations;
using BookingManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationRepository _educationRepository;
        public EducationController(IEducationRepository educationRepository) { 
            _educationRepository = educationRepository;
        }
        // kirimkan data untuk diInsert ke Database dengan metode POST
        [HttpPost]
        public IActionResult Create(Education edu)
        {
            var result = _educationRepository.Create(edu);
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
            var result = _educationRepository.GetAll();
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
            var result = _educationRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            return Ok(result);
        }
        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(Education edu)
        {
            var resultUpdate = _educationRepository.Update(edu);
            if (resultUpdate is false)
            {
                return BadRequest("Failed to Update data");
            }
            return Ok(resultUpdate);
        }
        // Delete data sesuai ID dengan metode DELETE
        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            var result = _educationRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            var delete = _educationRepository.Delete(result);
            if (delete is false)
            {
                return BadRequest("Failed to Delete data");
            }
            return Ok(delete);
        }
    }
}
