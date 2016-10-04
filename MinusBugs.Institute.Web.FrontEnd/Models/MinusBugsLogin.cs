using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    [Table("MinusBugsLogin")]
    public class MinusBugsLogin
    {
        [Key]
        public string username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime LastLogin { get; set; }
        public int IsLoginEnabled { get; set; }

        

    }
}