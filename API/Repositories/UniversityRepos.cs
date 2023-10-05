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
        private readonly BookingManagementDBContext _contextEmp;
        public UniversityRepos(BookingManagementDBContext context) : base(context) {
            _contextEmp = context;
        }

        public University? GetUniversity(string code, string name)
        {
            var getlast = _contextEmp.Set<University>()
                .Where(q => (q.Code == code && q.Name == name)).FirstOrDefault();
            return getlast;
        }
    }
}
