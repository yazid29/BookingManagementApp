namespace BookingManagementApp.Models;
public class Account : GeneralAtribute
{
    public Guid Guid { get; set; }
    public string Password { get; set; }
    public bool is_deleted { get; set; }
    public int otp { get; set; }
    public bool is_used { get; set; }
    public DateTime expired_date { get; set; }
}