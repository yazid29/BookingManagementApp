using System;
namespace BookingManagementApp.Models
{
    [Table("tb_m_account_roles")]
    public class AccountRole : GeneralAtribute
    {
        [Column("account_guid"]
        public Guid AccountGuid { get; set; }
        [Column("role_guid")]
        public Guid RoleGuid { get; set; }

    }
}