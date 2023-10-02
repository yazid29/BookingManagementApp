﻿using API.Contracts;
using API.DTO.Roles;
using BookingManagementApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    // atur routes agar dapat diakses oleh user
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository) { 
            _roleRepository = roleRepository;
        }
        // kirimkan data untuk diInsert ke Database dengan metode POST
        [HttpPost]
        public IActionResult Create(CreateRolesDto role)
        {
            var result = _roleRepository.Create(role);
            if (result is null)
            {
                return BadRequest("Failed to Create data");
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok((RoleDto) result);
        }
        // tampilkan semua data dengan metode GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _roleRepository.GetAll();
            if (!result.Any())
            {
                return BadRequest("Data not Found");
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            var data = result.Select(item => (RoleDto) item);
            return Ok(data);
        }
        // tampilkan data sesuai ID dengan metode GET
        [HttpGet("{guid}")]
        public IActionResult GetByGuid(Guid guid)
        {
            var result = _roleRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            // konversi sesuai yang ada di DTO untuk mengemas data
            return Ok((RoleDto) result);
        }
        // Update data sesuai ID dengan metode PUT
        [HttpPut]
        public IActionResult Update(RoleDto roleDto)
        {
            var entity = _roleRepository.GetByGuid(roleDto.Guid);
            if (entity is null)
            {
                return NotFound("Id Not Found");
            }
            // update data jika ada
            Role toUpdate = roleDto;
            toUpdate.CreatedDate = entity.CreatedDate;

            var result = _roleRepository.Update(toUpdate);
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
            var result = _roleRepository.GetByGuid(guid);
            if (result is null)
            {
                return NotFound("Id Not Found");
            }
            var delete = _roleRepository.Delete(result);
            if (delete is false)
            {
                return BadRequest("Failed to Delete data");
            }
            return Ok(delete);
        }
    }
}
