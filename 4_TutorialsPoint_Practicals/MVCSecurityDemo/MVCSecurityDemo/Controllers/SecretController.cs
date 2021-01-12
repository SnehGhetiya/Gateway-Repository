using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSecurityDemo.Controllers
{
    public class SecretController : Controller
    {
        // GET: Secret
        [Authorize(Users = "snehpatel690@gmail.com")]
        public ContentResult Secret()
        {
            return Content("Secret Information");
        }

        [AllowAnonymous]
        public ContentResult PublicInfo()
        {
            return Content("Public Infromation Is Here.");
        }
        /*public ActionResult Index()
        {
            return View();
        }*/
    }
}