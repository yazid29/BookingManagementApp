using API.Contracts;
using API.DTO.Universities;
using BookingManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class UniversityController : ControllerBase
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
            // konversi sesuai yang ada di DTO untuk mengemas data
            var data = result.Select(x => (UniversityDto) x );

            /*var universityDto = new List<UniversityDto>();
            foreach (var university in result)
            {
                universityDto.Add((UniversityDto) university);
            }*/

            return Ok(data);
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

            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok((UniversityDto) result);
        }

        // kirimkan data untuk diInsert ke Database dengan metode POST
        [HttpPost]
        public IActionResult Create(CreateUniversityDto universitydto)
        {
            var result = _universityRepository.Create(universitydto);
            if (result is null)
            {
                return BadRequest("Failed to Create data");
            }

            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok((UniversityDto) result);
        }

        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(UniversityDto universityDto)
        {
            var entity = _universityRepository.GetByGuid(universityDto.Guid);
            if (entity is null)
            {
                return NotFound("Id Not Found");
            }

            // update data jika ada
            University toUpdate = universityDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            var result = _universityRepository.Update(toUpdate);
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
            var result = _universityRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            var delete = _universityRepository.Delete(result);
            if (delete is false)
            {
                return BadRequest("Failed to Delete data");
            }
            return Ok(delete);
        }
    }
}
