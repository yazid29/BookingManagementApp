using API.Contracts;
using API.Data;
using BookingManagementApp.Models;

namespace API.Repositories
{
    // repository berfungsi sebagai pengganti View pada API,
    // namun Controller tidak langsung berhubungan dengan repository agar si Controller tidak mengetahui dengan yang terjadi pada Models
    // sehingga dihubungkan repository dengan suatu contract, dan controller hanya perlu memanggil contract
    public class UniversityRepos : IUniversityRepository
    {
        private readonly BookingManagementDBContext _context;

        public UniversityRepos(BookingManagementDBContext context)
        {
            _context = context;
        }
        // insert data
        public University? Create(University university)
        {
            try
            {
                _context.Set<University>().Add(university);
                _context.SaveChanges();
                return university;
            }
            catch
            {
                return null;
            }
        }
        // get all data
        public IEnumerable<University> GetAll()
        {
            return _context.Set<University>().ToList();
        }
        //  data by id
        public University? GetByGuid(Guid guid)
        {
            return _context.Set<University>().Find(guid);
        }

        // delete data 
        public bool Delete(University university)
        {
            try
            {
                _context.Set<University>().Remove(university);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(University university)
        {
            try
            {
                _context.Set<University>().Update(university);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
