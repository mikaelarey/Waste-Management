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
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Enter Personnel's First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Personnel's Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Your must provide a contact number")]
        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string ContactNumber { get; set; }

        public int Location { get; set; }

        //[Required(ErrorMessage = "Enter Your EmailID")]
        //[RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        //public string EmailID { get; set; }
    }
}