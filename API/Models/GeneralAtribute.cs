using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookingManagementApp.Models
{
    public class GeneralAtribute
    {
        [Key,Column("code", TypeName = "nvarchar(50)")]
        public Guid Guid { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
        [Column("modified_date")]
        public DateTime ModifiedDate { get; set; }
    }
}