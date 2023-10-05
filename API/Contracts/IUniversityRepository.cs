using API.Data;
using BookingManagementApp.Models;

namespace API.Contracts
{
    public interface IUniversityRepository : IGeneralRepos<University>
    {
        University? GetUniversity(string code, string name);
        /*
        IEnumerable<University> GetAll();
        University? GetByGuid(Guid guid);
        University? Create(University university);
        bool Update(University university);
        bool Delete(University university);
        */
    }
}
