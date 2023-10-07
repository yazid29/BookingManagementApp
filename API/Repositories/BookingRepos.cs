using API.Contracts;
using API.Data;
using API.DTO.Bookings;
using API.DTO.Employees;
using BookingManagementApp.Models;
using System.Data;

namespace API.Repositories
{
    public class BookingRepos : GeneralRepos<Booking>, IBookingRepository
    {
        public BookingRepos(BookingManagementDBContext context) : base(context) {
        }
    }
}
