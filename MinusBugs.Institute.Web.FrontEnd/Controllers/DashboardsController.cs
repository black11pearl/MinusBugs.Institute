using AnalyticsApi;
using MinusBugs.Institute.Web.FrontEnd.Models;
using MinusBugs.Institute.Web.FrontEnd.Models.dbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Inspinia_MVC5.Controllers
{
    [Authorize]
    public class DashboardsController : Controller
    {
       
        public ActionResult Dashboard_1()
        {
            return View();
        }

        public ActionResult Dashboard_2()
        {
            return View();
        }

        public ActionResult Dashboard_3()
        {
            string fyear = DateTime.Now.Year.ToString();
            string fmonth = DateTime.Now.Month.ToString("d2");
            string fday = DateTime.Now.Day.ToString("d2");



            string toyear = DateTime.Now.Year.ToString();
            string tomonth = DateTime.Now.Month.ToString("d2");
            string today = DateTime.Now.Day.ToString("d2");

            string fromdate = fyear + "-" + fmonth + "-" + fday;
            string todate = toyear+ "-" + tomonth + "-" + today;
            var dashboard = new AnalyticsService(new AnalyticsDataProvider("www.MinusBugs.com", HttpWrapper.Standard)).Username("support@minusbugs.com").Password("MyPersonal@1").Logon().Profile(96050771).GetDashboard(fromdate, todate);

            string Visitper = dashboard.NewVisitsPercent.ToString();
            string clicks = dashboard.PageViews.ToString();
            ViewBag.Visitper = Visitper;
            ViewBag.clicks = clicks;
            return View();
            
        }

    }
}