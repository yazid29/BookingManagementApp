using API.Contracts;
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
        public IActionResult Create(Booking booking)
        {
            var result = _bookingRepository.Create(booking);
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
            var result = _bookingRepository.GetAll();
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
            var result = _bookingRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            return Ok(result);
        }
        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(Booking booking)
        {
            var resultUpdate = _bookingRepository.Update(booking);
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
