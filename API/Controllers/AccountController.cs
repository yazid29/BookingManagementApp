using API.Contracts;
using API.DTO.Accounts;
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
        public IActionResult Create(CreateAccountDto accountDto)
        {
            var result = _accountRepository.Create(accountDto);
            if (result is null)
            {
                return BadRequest("Failed to Create data");
            }
            // konversi sesuai yang ada di DTO untuk mengemas data tanpa password
            return Ok((ViewAccountDto) result);
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
            // konversi sesuai yang ada di DTO untuk mengemas data tanpa password
            var data = result.Select(item => (ViewAccountDto) item);
            return Ok(data);
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
            // konversi sesuai yang ada di DTO untuk mengemas data tanpa password
            return Ok((ViewAccountDto)result);
        }
        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(AccountDto accountDto)
        {
            var entity = _accountRepository.GetByGuid(accountDto.Guid);
            if (entity is null)
            {
                return NotFound("Id Not Found");
            }

            Account toUpdate = accountDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            var result = _accountRepository.Update(toUpdate);
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
