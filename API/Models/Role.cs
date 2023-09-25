using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookingManagementApp.Models
{
    [Table("tb_m_roles")]
    public class Role : GeneralAtribute
    {
        [Column("name", TypeName = "nvarchar(100)")]
        public string Name { get; set; }
    }
}