using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookingManagementApp.Models
{
    [Table("tb_m_educations")]
    public class Education : GeneralAtribute
    {
        [Column("major", TypeName = "nvarchar(100)")]
        public string Major { get; set; }
        [Column("degre", TypeName = "nvarchar(100)")]
        public string Degree { get; set; }
        [Column("gpa")]
        public float Gpa { get; set; }
        [Column("university_guid")]
        public Guid UniversityGuid { get; set; }
    }
}