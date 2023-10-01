using API.Contracts;
using BookingManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class AccountRoleController : ControllerBase
    {
        private readonly IAccountRoleRepository _accountRoleRepository;
        public AccountRoleController(IAccountRoleRepository accountRoleRepository) { 
            _accountRoleRepository = accountRoleRepository;
        }
        // kirimkan data untuk diInsert ke Database dengan metode POST
        [HttpPost]
        public IActionResult Create(AccountRole accountRole)
        {
            var result = _accountRoleRepository.Create(accountRole);
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
            var result = _accountRoleRepository.GetAll();
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
            var result = _accountRoleRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            return Ok(result);
        }
        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(AccountRole accountRole)
        {
            var resultUpdate = _accountRoleRepository.Update(accountRole);
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
            var result = _accountRoleRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            var delete = _accountRoleRepository.Delete(result);
            if (delete is false)
            {
                return BadRequest("Failed to Delete data");
            }
            return Ok(delete);
        }
    }
}
