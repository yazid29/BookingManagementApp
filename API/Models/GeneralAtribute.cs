using System;
namespace BookingManagementApp.Models
{
    public class GeneneralAtribute
    {
        [Key,Column("code", TypeName = "nvarchar(50)")]
        public Guid Guid { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
    }
}