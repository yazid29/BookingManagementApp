using API.Contracts;
using API.DTO.Employees;
using BookingManagementApp.Models;

namespace API.Utilities.Handler
{
    public class GenerateHandler
    {
        public static string GenerateNik(string? employeeNik = null)
        {
            // generate NIK bila tidak ada data. 
            var generateNik = "111111";
            if (employeeNik is null)
            {
                return generateNik;
            }

            // jika ada data, nik data yang terakhir ditambahkan satu
            generateNik = Convert.ToString(Convert.ToInt32(employeeNik) + 1);
            return generateNik;
        }
    }
}
