using API.DTO.Rooms;
using API.Utilities.Enums;
using BookingManagementApp.Models;

namespace API.DTO.Bookings
{
    public class CreateBookingDto 
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public StatusLevel Status { get; set; }
        public string Remarks { get; set; }
        public static implicit operator Booking(CreateBookingDto CreateDto)
        {
            return new Booking
            {
                StartDate = CreateDto.StartDate,
                EndDate = CreateDto.EndDate,
                Status = CreateDto.Status,
                Remarks = CreateDto.Remarks,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
        }
    }
}
