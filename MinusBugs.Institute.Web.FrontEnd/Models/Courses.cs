using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    [Table("Courses")]
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Title Required")]
        public string CourseTitle { get; set; }

        [Required(ErrorMessage = "Course Description Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Course Type Required")]
        public string CourseType { get; set; } //  Crash Course  |  Normal Course  |  Project
        public int Duration_in_Hrs { get; set; }
        public decimal CourseFee { get; set; }

    }
}