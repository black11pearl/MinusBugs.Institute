﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inspinia_MVC5.Controllers
{
    [Authorize]
    public class MiscellaneousController : Controller
    {

        public ActionResult GoogleMaps()
        {
            return View();
        }

        public ActionResult CodeEditor()
        {
            return View();
        }

        public ActionResult ModalWindow()
        {
            return View();
        }

        public ActionResult NestableList()
        {
            return View();
        }

        public ActionResult Validation()
        {
            return View();
        }

        public ActionResult Notification()
        {
            return View();
        }

        public ActionResult Timeline_second_version()
        {
            return View();
        }

        public ActionResult Forum_view()
        {
            return View();
        }

        public ActionResult Forum_post_view()
        {
            return View();
        }
	}
}