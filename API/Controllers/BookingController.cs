using API.Contracts;
using API.DTO.Bookings;
using BookingManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository) { 
            _bookingRepository = bookingRepository;
        }
        // kirimkan data untuk diInsert ke Database dengan metode POST
        [HttpPost]
        public IActionResult Create(CreateBookingDto bookingDto)
        {
            var result = _bookingRepository.Create(bookingDto);
            if (result is null)
            {
                return BadRequest("Failed to Create data");
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok((BookingDto) result);
        }
        // tampilkan semua data dengan metode GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _bookingRepository.GetAll();
            if (!result.Any())
            {
                return BadRequest("Data not Found");
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            var data = result.Select(item => (BookingDto) item);
            return Ok((BookingDto)result);
        }
        // tampilkan data sesuai ID dengan metode GET
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _bookingRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok(result);
        }
        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(BookingDto bookingDto)
        {
            var entity = _bookingRepository.GetByGuid(bookingDto.Guid);
            if (entity is null)
            {
                return NotFound("Id Not Found");
            }

            Booking toUpdate = bookingDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            var result = _bookingRepository.Update(toUpdate);
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
            var result = _bookingRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            var delete = _bookingRepository.Delete(result);
            if (delete is false)
            {
                return BadRequest("Failed to Delete data");
            }
            return Ok(delete);
        }
    }
}
