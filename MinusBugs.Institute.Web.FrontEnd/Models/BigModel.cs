using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    public class BigModel
    {
        public Student StudentModel { get; set; }
        public Courses CourseModel { get; set; }

        public PaymentDetails PaymentModel { get; set; }
    }
}