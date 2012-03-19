using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yame.Core;

namespace Yame.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {

        public HomeController()
        {

        }
        public ActionResult Index()
        {
            ViewData["Message"] = "Hi,Yame";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
