using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    [Table("PaymentDetails")]
    public class PaymentDetails
    {
        [Key]
        public int PaymentId { get; set; }
        public int Pay_CourseId { get; set; }
        public int Pay_Admno { get; set; }
        public decimal Pay_AmountPaid { get; set; }
        public decimal Pay_TotBalanceToPay { get; set; }
        public string Pay_MadeThru { get; set; }
        public DateTime PaymentDate { get; set; }

    }
}