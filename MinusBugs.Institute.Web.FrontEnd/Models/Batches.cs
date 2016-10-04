using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    public class Batches
    {
        [Key]
        public int BatchId { get; set; }

        [Required(ErrorMessage = "Batch Name Required")]
        public string BatchName { get; set; }

        [Required(ErrorMessage = "Course Id Required")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Faculty Required")]
        public int FacultyId { get; set; }

        [Required(ErrorMessage = "Start Date Required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Start End Date Required")]
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public int MaxStudCount { get; set; }
       

    }
}