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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(MinusBugsLogin objLogin)
        {
            UserLogin user_login = new UserLogin();
            MinusBugsLogin ml = user_login.checklogin(objLogin.username, objLogin.Password);
           
        
            Session["role"]=ml.Role;
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = js.Serialize(ml);
            return Json(strJSON);
        }
    }
}