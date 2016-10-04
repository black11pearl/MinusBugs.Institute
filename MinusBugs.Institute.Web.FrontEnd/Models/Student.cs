
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public int Admno { get; set; }
       
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [Required]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> Dob { get; set; }

        [Display(Name = "Gender")]
        [Required]
        public string Gender { get; set; }

        [Display(Name = "Contact Number")]
        [Required]
        public string MobileNumber { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Guardian Number")]
        [Required]
        public string GuardianNumber { get; set; }

        [Display(Name = "Address")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Adress { get; set; }

        [Display(Name = "City")]
        [Required]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required]
        public string State { get; set; }

        [Display(Name = "Pincode")]
        [Required]
        public Nullable<int> Pincode { get; set; }

        public string College { get; set; }
        public string Qualification { get; set; }
        public string YearofPassing { get; set; }
        public string Technology { get; set; }
        public string CourseType { get; set; }

        public string Regsitered { get; set; }

        

        [Display(Name = "Registration Date")]
        [Required]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateofRegistration { get; set; }

        //[Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateofJoining { get; set; }

        //[Display(Name = "Completion Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> DateofCompletion { get; set; }

        [Display(Name = "Referral")]
        [Required]
        public string ReferredBy { get; set; }

        public string Status { get; set; }
        //public string Discontinued { get; set; }

    }
}