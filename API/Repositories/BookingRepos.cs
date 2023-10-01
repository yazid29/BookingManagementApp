using API.Contracts;
using API.Data;
using BookingManagementApp.Models;
using System.Data;

namespace API.Repositories
{
    public class BookingRepos : IBookingRepository
    {
        private readonly BookingManagementDBContext _context;

        public BookingRepos(BookingManagementDBContext context)
        {
            _context = context;
        }
        Booking? IBookingRepository.Create(Booking booking)
        {
            try
            {
                _context.Set<Booking>().Add(booking);
                _context.SaveChanges();
                return booking;
            }
            catch
            {
                return null;
            }
        }

        bool IBookingRepository.Delete(Booking booking)
        {
            try
            {
                _context.Set<Booking>().Remove(booking);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        IEnumerable<Booking> IBookingRepository.GetAll()
        {
            return _context.Set<Booking>().ToList();
        }

        Booking? IBookingRepository.GetByGuid(Guid guid)
        {
            return _context.Set<Booking>().Find(guid);
        }

        bool IBookingRepository.Update(Booking booking)
        {
            try
            {
                _context.Set<Booking>().Update(booking);
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
