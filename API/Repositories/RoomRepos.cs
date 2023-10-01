using API.Contracts;
using API.Data;
using BookingManagementApp.Models;

namespace API.Repositories
{
    public class RoomRepos : IRoomRepository
    {
        private readonly BookingManagementDBContext _context;

        public RoomRepos(BookingManagementDBContext context)
        {
            _context = context;
        }

        Room? IRoomRepository.Create(Room room)
        {
            try
            {
                _context.Set<Room>().Add(room);
                _context.SaveChanges();
                return room;
            }
            catch
            {
                return null;
            }
        }

        IEnumerable<Room> IRoomRepository.GetAll()
        {
            return _context.Set<Room>().ToList();
        }

        bool IRoomRepository.Delete(Room room)
        {
            try
            {
                _context.Set<Room>().Remove(room);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        Room? IRoomRepository.GetByGuid(Guid guid)
        {
            return _context.Set<Room>().Find(guid);
        }

        bool IRoomRepository.Update(Room room)
        {
            try
            {
                _context.Set<Room>().Update(room);
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
