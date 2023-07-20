using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JobPortalLibrary.Controller
{
    public class AccountUser
    {
        public string Code { get; set; }
        public string Seekercode { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression("^((?!^First Name$)[a-zA-Z '])+$", ErrorMessage = "Please enter correct Name")]
        public string SeekerName { get; set; }      
        public string Employercode { get; set; } 
        public string EmployerName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [Display(Name = "Contact No")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public Int64 ContactNo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = "Password")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "Select Category")]
        public string Category { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string ResumePDF { get; set; }
        public string ProfileIMG { get; set; }

        public string EmailId1 { get; set; }
        public string Password1 { get; set; }

    }
}
