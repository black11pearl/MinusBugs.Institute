﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    [Authorize]
    public class CSSAnimationsController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
	}
}