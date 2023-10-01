using BookingManagementApp.Models;

namespace API.Contracts
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAll();
        Booking? GetByGuid(Guid guid);
        Booking? Create(Booking booking);
        bool Update(Booking booking);
        bool Delete(Booking booking);
    }
}
