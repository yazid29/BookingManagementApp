using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingManagementApp.Models
{
    [Table("tb_m_accounts")]
    public class Account : GeneralAtribute
    {
        
        [Column("password", TypeName = "nvarchar(100)")]
        public string Password { get; set; }
        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
        [Column("otp")]
        public int Otp { get; set; }
        [Column("is_used")]
        public bool IsUsed { get; set; }
        [Column("expired_date")]
        public DateTime ExpiredDate { get; set; }

        // Cardinality One To One
        public Employee? Employee { get; set; }
        // Cardinality One To Many
        public ICollection<AccountRole>? AccountRoles { get; set;}
    }
}