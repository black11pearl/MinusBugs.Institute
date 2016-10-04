using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    public class Salary
    {
        public int SalaryId { get; set; }
        public int Staff_Id { get; set; }
        public decimal Basic_Pay { get; set; }
        public decimal Extras { get; set; }
        public decimal NetSalary { get; set; }
      
    }
}