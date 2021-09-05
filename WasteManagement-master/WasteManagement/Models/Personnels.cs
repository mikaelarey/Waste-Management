using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WasteManagement.Models
{
    public class Personnels
    {
        [Key]
        public int PersonnelID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter Personnel's First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter Personnel's Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Your must provide a contact number")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string ContactNumber { get; set; }

        //public int LocationId { get; set; }

        //[Required(ErrorMessage = "Enter Your EmailID")]
        //[RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        //public string EmailID { get; set; }
    }

    public class PersonnelsIndexViewModel
    {
        public List<Personnels> Personnels { get; set; }
        public Personnels Personnel { get; set; }
    }
}