using System;
using System.ComponentModel.DataAnnotations;

namespace API.Utilities.Enums
{
    
    public enum StatusLevel
    {
        [Display(Name = "Requested")] Requested = 0,
        [Display(Name = "Approved")] Approved = 1,
        [Display(Name = "Rejected")] Rejected = 2,
        [Display(Name = "Canceled")] Canceled = 3,
        [Display(Name = "Completed")] Completed = 4,
        [Display (Name = "On Going")] Ongoing = 5
    }
}