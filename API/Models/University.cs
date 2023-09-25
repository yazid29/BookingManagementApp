using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingManagementApp.Models
{
    [Table("tb_m_universities")]
    public class University : GeneralAtribute
    {
        [Column("code", TypeName = "nvarchar(50)")]
        public string Code { get; set; }
        [Column("name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime ModifiedDate { get; set; }
    }
}