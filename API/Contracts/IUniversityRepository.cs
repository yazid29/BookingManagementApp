using API.Data;
using BookingManagementApp.Models;

namespace API.Contracts
{
    public interface IUniversityRepository 
    {
        IEnumerable<University> GetAll();
        University? GetByGuid(Guid guid);
        University? Create(University university);
        bool Update(University university);
        bool Delete(University university);
    }
}
