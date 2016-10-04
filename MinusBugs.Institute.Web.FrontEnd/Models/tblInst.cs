using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    [Table("tblInst")]
    public class tblInst
    {
        [Key]
        public int InstituteId { get; set; }
        [Display(Name = "Institute Name")]
        [Required]
        public string InstituteName { get; set; }
        [Display(Name = "Contact Person")]
        [Required]
        public string ContactPerson { get; set; }
        [Display(Name = "E-mail address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        [Required]
        public string Phone { get; set; }
        [Display(Name = "Address")]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        public string Discontinued { get; set; }
    }
}