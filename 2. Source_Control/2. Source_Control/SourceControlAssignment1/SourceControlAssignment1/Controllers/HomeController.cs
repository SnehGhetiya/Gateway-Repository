using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SourceControlAssignment1.Models;

namespace SourceControlAssignment1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Employee employee)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                return View();
            }
            return View();
        }
    }
}