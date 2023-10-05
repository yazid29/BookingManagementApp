using System;
using System.ComponentModel.DataAnnotations;

namespace API.Utilities.Enums
{

    public enum Gender
    {
        [Display(Name = "Female")] Female = 0,
        [Display(Name = "Male")] Male = 1
    }
}