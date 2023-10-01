using BookingManagementApp.Models;

namespace API.Contracts
{
    public interface IEducationRepository
    {
        IEnumerable<Education> GetAll();
        Education? GetByGuid(Guid guid);
        Education? Create(Education edu);
        bool Update(Education edu);
        bool Delete(Education edu);
    }
}
