using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinusBugs.Institute.Web.FrontEnd.Models
{
    public class Features
    {
        public int FeatureId { get; set; }
        public int CenterId { get; set; }
        public bool IsFeeEnabled { get; set; }
        public bool IsPayworldEnabled { get; set; }
        public bool IsProjectTrackingEnabled { get; set; }
        public DateTime Exp_date { get; set; }

    }
}