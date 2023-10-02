using API.Contracts;
using API.Data;
using BookingManagementApp.Models;

namespace API.Repositories
{
    public class RoomRepos : GeneralRepos<Room>, IRoomRepository
    {
        public RoomRepos(BookingManagementDBContext context) : base(context) { }
    }
}
