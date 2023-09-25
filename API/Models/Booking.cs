using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookingManagementApp.Models
{
    [Table("tb_m_bookings")]
    public class Booking : GeneralAtribute
    {
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; }
        [Column("status")]
        public StatusLevel Status { get; set; }
        [Column("remarks", TypeName = "nvarchar(255)")]
        public string Remarks { get; set; }
        [Column("room_guid")]
        public Guid RoomGuid { get; set; }
        [Column("employee_guid")]
        public Guid EmployeeGuid { get; set; }
    }
}