namespace BookingManagementApp.Models;
public class Employees : GeneralAtribute
{
    public Guid Guid { get; set; }
    public string Nik { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Datetime BirthDate { get; set; }
    public int Gender { get; set; }
    public Datetime HiringDate { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

}