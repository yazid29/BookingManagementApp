﻿using API.Utilities.Enums;
using BookingManagementApp.Models;

namespace API.DTO.Employees
{
    public class CreateEmployeeDto 
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static implicit operator Employee(CreateEmployeeDto CreateDto)
        {
            // setelah method dipanggil akan otomatis konversi isi atribut
            // konversi DTO ke Model agar dapat di Insert oleh Repository-Model
            return new Employee
            {
                Guid = Guid.NewGuid(),
                FirstName = CreateDto.FirstName,
                LastName = CreateDto.LastName,
                BirthDate = CreateDto.BirthDate,
                Gender = CreateDto.Gender,
                HiringDate = CreateDto.HiringDate,
                Email = CreateDto.Email,
                PhoneNumber = CreateDto.PhoneNumber,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
