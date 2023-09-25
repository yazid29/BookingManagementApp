namespace BookingManagementApp.Models;
public class AccountRole : GeneralAtribute
{
    public Guid Guid { get; set; }
    public Guid AccountGuid { get; set; }
    public Guid RoleGuid { get; set; }

}