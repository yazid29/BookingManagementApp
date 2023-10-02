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
            // setelah method dipanggil akan otomatis konversi isi atribut
            // konversi DTO ke Model University agar dapat di Insert oleh Repository-Model
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
