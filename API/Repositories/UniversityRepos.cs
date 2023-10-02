using API.Contracts;
using API.Data;
using BookingManagementApp.Models;

namespace API.Repositories
{
    // repository berfungsi sebagai pengganti View pada API,
    // namun Controller tidak langsung berhubungan dengan repository agar si Controller tidak mengetahui dengan yang terjadi pada Models
    // sehingga dihubungkan repository dengan suatu contract, dan controller hanya perlu memanggil contract
    public class UniversityRepos : GeneralRepos<University>, IUniversityRepository
    {
        public UniversityRepos(BookingManagementDBContext context) : base(context) { }
    }
}
