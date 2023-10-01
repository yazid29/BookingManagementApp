using API.Contracts;
using BookingManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository) { 
            _accountRepository = accountRepository;
        }
        // kirimkan data untuk diInsert ke Database dengan metode POST
        [HttpPost]
        public IActionResult Create(Account account)
        {
            var result = _accountRepository.Create(account);
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
            var result = _accountRepository.GetAll();
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
            var result = _accountRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            return Ok(result);
        }
        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(Account account)
        {
            var resultUpdate = _accountRepository.Update(account);
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
            var result = _accountRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            var delete = _accountRepository.Delete(result);
            if (delete is false)
            {
                return BadRequest("Failed to Delete data");
            }
            return Ok(delete);
        }
    }
}
