using API.DTO.Bookings;
using API.Utilities.Enums;
using BookingManagementApp.Models;

namespace API.DTO.Employees
{
    public class EmployeeDto : GeneralGuid
    {
        public string Nik { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static explicit operator EmployeeDto(Employee employee)
        {
            return new EmployeeDto
            {
                Guid = employee.Guid,
                Nik = employee.Nik,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                HiringDate = employee.HiringDate,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
            };
        }

        public static implicit operator Employee(EmployeeDto employeeDto)
        {
            return new Employee
            {
                Guid = employeeDto.Guid,
                Nik = employeeDto.Nik,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                BirthDate = employeeDto.BirthDate,
                Gender = employeeDto.Gender,
                HiringDate = employeeDto.HiringDate,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
