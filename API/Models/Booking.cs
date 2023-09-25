namespace BookingManagementApp.Models;
public class Booking : GeneralAtribute
{
    public Guid Guid { get; set; }
    public Datetime StartDate { get; set; }
    public Datetime EndDate { get; set; }
    public int Status { get; set; }
    public string Remarks { get; set; }
    public Guid RoomGuid { get; set; }
    public Guid EmployeeGuid { get; set; }
}