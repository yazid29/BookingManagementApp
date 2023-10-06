using API.Contracts;
using API.DTO.Employees;
using API.DTO.Universities;
using API.Utilities.Handler;
using BookingManagementApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [EnableCors]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _universityRepository.GetAll();
            if (!result.Any())
            {
                //return BadRequest("Data not Found");
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            var data = result.Select(x => (UniversityDto)x);

            //return Ok(data);
            return Ok(new ResponseOKHandler<IEnumerable<UniversityDto>>(data));
        }

        // tampilkan data sesuai ID dengan metode GET
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _universityRepository.GetByGuid(guid);
            if (result is null)
            {
                //return NotFound("Id Not Found");
                return NotFound(new ResponseErrorHandler
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = HttpStatusCode.NotFound.ToString(),
                    Message = "Data Not Found"
                });
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            //return Ok((EmployeeDto)result);
            return Ok(new ResponseOKHandler<UniversityDto>((UniversityDto)result));
        }

        // kirimkan data untuk diInsert ke Database dengan metode POST
        [HttpPost]
        public IActionResult Create(CreateUniversityDto universitydto)
        {
            try
            {
                var result = _universityRepository.Create(universitydto);
                // konversi sesuai yang ada di DTO untuk mengemas data
                return Ok(new ResponseOKHandler<UniversityDto>((UniversityDto)result));
            }
            catch (ExceptionHandler ex)
            {
                // message error jika gagal Insert into DB
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to create data",
                    Error = ex.Message
                });
            }
        }

        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(UniversityDto universityDto)
        {
            try
            {
                var entity = _universityRepository.GetByGuid(universityDto.Guid);
                if (entity is null)
                {
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }

                University toUpdate = universityDto;
                toUpdate.CreatedDate = entity.CreatedDate;

                _universityRepository.Update(toUpdate);

                return Ok(new ResponseOKHandler<string>("Data Updated"));
            }
            catch (ExceptionHandler ex)
            {
                // message error jika gagal update
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to update data",
                    Error = ex.Message
                });
            }
        }

        // Delete data sesuai ID dengan metode DELETE
        [HttpDelete]
        public IActionResult Delete(Guid guid)
        {
            try
            {
                var result = _universityRepository.GetByGuid(guid);
                if (result is null)
                {
                    //return NotFound("Id Not Found");
                    return NotFound(new ResponseErrorHandler
                    {
                        Code = StatusCodes.Status404NotFound,
                        Status = HttpStatusCode.NotFound.ToString(),
                        Message = "Data Not Found"
                    });
                }
                _universityRepository.Delete(result);
                //return Ok(delete);
                return Ok(new ResponseOKHandler<string>("Data Deleted"));
            }
            catch (ExceptionHandler ex)
            {
                // message error jika gagal delete data
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorHandler
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Failed to create data",
                    Error = ex.Message
                });
            }
        }
    }
}
