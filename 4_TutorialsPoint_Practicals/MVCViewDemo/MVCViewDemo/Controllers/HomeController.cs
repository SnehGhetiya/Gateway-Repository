using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCViewDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public string MyController()
        {
            return "Hi there this is a MVC View demo.";
        }

        public ActionResult MyView()
        {
            return View();
        }
    }
}