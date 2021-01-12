using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCControllerDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public string GetAllCustomers()
        {
            return @"<ul>
                <li>Stephen King</li>
                <li>Mark Watson</li>
                <li>David Kapoor</li>
                <li>Mark Khanna</li>
                </ul>";
        }
    }

}