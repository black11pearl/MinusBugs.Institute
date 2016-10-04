using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    [Table("FeeSchedule")]
    public class FeeSchedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int Sch_Admno { get; set; }
        public int Sch_CourseId { get; set; }
        public decimal Sch_Amount { get; set; }

        public decimal Sch_AmountPaid { get; set; }

        public decimal Sch_BalanceToPay { get; set; }
        public DateTime Sch_Date { get; set; }
       
    }
}