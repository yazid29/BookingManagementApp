using API.Contracts;
using API.DTO.Employees;
using BookingManagementApp.Models;

namespace API.Utilities.Handler
{
    public class GenerateHandler
    {
        public static string GenerateNik(Employee employee)
        {
            // generate NIK bila ada data. 
            var generateNik = "111111";
            if (employee is null)
            {
                return generateNik;
            }
            // data yang terakhir NIKnya ditambahkan satu
            generateNik = Convert.ToString(Convert.ToInt32(employee.Nik) + 1);
            return generateNik;
        }
    }
}
