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
        public IActionResult Create(CreateEducationDto eduDto)
        {
            var result = _educationRepository.Create(eduDto);
            if (result is null)
            {
                return BadRequest("Failed to Create data");
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok((EducationDto) result);
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
            // konversi sesuai yang ada di DTO untuk mengemas data
            var data = result.Select(item => (EducationDto) item);
            return Ok(data);
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
            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok((EducationDto)result);
        }
        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(EducationDto eduDto)
        {
            var entity = _educationRepository.GetByGuid(eduDto.Guid);
            if (entity is null)
            {
                return NotFound("Id Not Found");
            }

            Education toUpdate = eduDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            var result = _educationRepository.Update(toUpdate);
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
