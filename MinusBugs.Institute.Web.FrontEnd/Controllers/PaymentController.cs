using MinusBugs.Institute.Web.FrontEnd.Models;
using MinusBugs.Institute.Web.FrontEnd.Models.dbOperations;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MinusBugs.Institute.Web.FrontEnd.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        // GET: Payment
        public ActionResult Index()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Index(string paymentId)
        {
            Session["paymentId"] = paymentId;
            return Json(paymentId);
        }
        public ActionResult AddNewSchedule(string Admno, string CourseId, string Amount,string Date,string BalanceToPay)
        {
            FeeSchedule feeschedule = new FeeSchedule();
            feeschedule.Sch_Admno = Convert.ToInt32(Admno);
            feeschedule.Sch_CourseId =Convert.ToInt32(CourseId);
            feeschedule.Sch_Amount =Convert.ToDecimal(Amount);
            feeschedule.Sch_BalanceToPay = Convert.ToDecimal(BalanceToPay);
            feeschedule.Sch_AmountPaid = 0;
            feeschedule.Sch_Date = Convert.ToDateTime(Date);
           // feeschedule.Sch_Date = DateTime.Now;

            FeeDbOperations fdb = new FeeDbOperations();
            fdb.AddFeeSchedule(feeschedule);

            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = js.Serialize(feeschedule);
            return Json(strJSON);
           
        }

        public ActionResult MakePayment(string admno,string courseId,string amount,string totbalancetopay)
        {
            PaymentDetails paydetails = new PaymentDetails();
            paydetails.Pay_Admno =Convert.ToInt32(admno);
            paydetails.Pay_CourseId =Convert.ToInt32(courseId);
            paydetails.Pay_AmountPaid = Convert.ToDecimal(amount);
            paydetails.Pay_TotBalanceToPay = Convert.ToDecimal(totbalancetopay);
            paydetails.Pay_MadeThru = "Cash";
            paydetails.PaymentDate = DateTime.Now;

            FeeDbOperations feeoperations = new FeeDbOperations();
            string payid= feeoperations.MakeANewPayment(paydetails);
           
            return Json(payid) ;
        }
      
        public ActionResult Invoice()
        {
            dynamic mymodel = new ExpandoObject();
            TempData["paymentId"] = Session["paymentId"].ToString();

            FeeDbOperations fd = new FeeDbOperations();
            PaymentDetails paymentdetails = fd.GetPaymentDetails(Convert.ToInt32(Session["paymentId"].ToString()));
           

            mymodel.PaymentDetails = paymentdetails;

            CourseOperations coperations = new CourseOperations();

            StudentOperations sop = new StudentOperations();

            BigModel bgmodel = new BigModel();
            bgmodel.StudentModel= sop.GetStudent(paymentdetails.Pay_Admno);
            bgmodel.CourseModel= coperations.GetCourse(paymentdetails.Pay_CourseId);
            bgmodel.PaymentModel = paymentdetails;

            TempData["BigModel"] = bgmodel;
            return View();

        }
        public ActionResult PrintInvoice()
        {
            dynamic mymodel = new ExpandoObject();
            TempData["paymentId"] = Session["paymentId"].ToString();

            FeeDbOperations fd = new FeeDbOperations();
            PaymentDetails paymentdetails = fd.GetPaymentDetails(Convert.ToInt32(Session["paymentId"].ToString()));


            mymodel.PaymentDetails = paymentdetails;

            CourseOperations coperations = new CourseOperations();

            StudentOperations sop = new StudentOperations();

            BigModel bgmodel = new BigModel();
            bgmodel.StudentModel = sop.GetStudent(paymentdetails.Pay_Admno);
            bgmodel.CourseModel = coperations.GetCourse(paymentdetails.Pay_CourseId);
            bgmodel.PaymentModel = paymentdetails;

            TempData["BigModel"] = bgmodel;

            return View();

        }

    }
}