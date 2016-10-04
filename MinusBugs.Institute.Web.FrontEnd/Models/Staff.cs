using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        public string Username { get; set; }

        [Required(ErrorMessage = "Faculty Name  Required")]
        [Display(Name = "Name")]
        public string StaffName { get; set; }

        [Required(ErrorMessage = "Address  Required")]
        [Display(Name ="Address")]
        public string Staff_Address { get; set; }

        [Required(ErrorMessage = "Email Id  Required")]
        [Display(Name = "Email")]
        public string Staff_Email { get; set; }
      

        [Required(ErrorMessage = "Bate of Birth  Required")]
        [Display(Name = "DOB")]
        public DateTime Staff_Dob { get; set; }

      
        [Required(ErrorMessage = "Contact Number  Required")]
        [Display(Name = "Contact 1")]
        public string Staff_ContactNumber { get; set; }

        [Display(Name = "Qualification")]
        public string Staff_Qualification { get; set; }

        //[Required(ErrorMessage = "Technology Required")]
        [Display(Name = "Technology")]
        public string Staff_Technology { get; set; }

        [Required(ErrorMessage = "Salary  Required")]
        [Display(Name = "Salary")]
        public decimal Staff_Salary { get; set; }

        [Display(Name = "Designation")]
        public string Staff_Designation { get; set; }

        [Display(Name = "Joining Date")]
        public DateTime Staff_Date_of_Joining { get; set; }


        public int Staff_Status { get; set; }

        [Display(Name = "Max-Leave")]
        public int Max_Leave_Granted_Per_Month { get; set; }

        public string AboutMe { get; set; }

    }
}