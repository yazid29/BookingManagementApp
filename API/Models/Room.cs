namespace BookingManagementApp.Models;
public class Room : GeneralAtribute
{
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public int Floor { get; set; }
    public int Capacity { get; set; }
}