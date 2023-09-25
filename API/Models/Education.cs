namespace BookingManagementApp.Models;
public class Education : GeneralAtribute
{ 
    public Guid Guid { get; set; }
    public string Major { get; set; }
    public string Degree { get; set; }
    public float Gpa { get; set; }
    public Guid UniversityGuid { get; set; }
    //public DateTime CreatedDate { get; set; }
    //public DateTime ModifiedDate { get; set; }
}