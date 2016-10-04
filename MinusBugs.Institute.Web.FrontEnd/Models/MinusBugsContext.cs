
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    public class MinusBugsContext : DbContext
    {
        public DbSet<MinusBugsLogin> Login { get; set; }
        public DbSet<Student> StudentsData { get; set; }
        public DbSet<Staff> StaffData { get; set; }

        public DbSet<Courses> CourseData { get; set; }
        public DbSet<CourseGraph> CourseGraphData { get; set; }
        public DbSet<FeeSchedule> FeeScheduleData { get; set; }
        public DbSet<PaymentDetails> PaymentData { get; set; }
        public DbSet<tblInst> tblInstData { get; set; }


    }
}