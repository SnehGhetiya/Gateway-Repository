using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SourceControlFinalAssignment.Models;

namespace SourceControlFinalAssignment.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(HomeController));
        private readonly SampleEntities db = new SampleEntities();
        public ActionResult Index()
        {
            return View(db.tbl_User.ToList());
        }

        [HttpPost]
        public ActionResult Index(tbl_User model)
        {
            return View(model);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tbl_User model, HttpPostedFileBase UserImage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string filename = Path.GetFileName(UserImage.FileName);
                    string _filename = DateTime.Now.ToString("ddMMyyyyHHmmss") + filename;
                    string extension = Path.GetExtension(UserImage.FileName);
                    model.Image = "~/Images/" + _filename;
                    string path = Path.Combine(Server.MapPath("~/Images/"), _filename);

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        db.tbl_User.Add(model);
                        if (db.SaveChanges() > 0)
                        {
                            UserImage.SaveAs(path);
                            ViewBag.msg = "Image added";
                            ModelState.Clear();
                            return RedirectToAction("Index");
                        }
                    }
                    else
                    {
                        ViewBag.msg = "Image type is not valid.";
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e.ToString());
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_Login model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new SampleEntities())
                    {
                        var obj = db.tbl_User.Where(x => x.Username.Equals(model.Username) && x.Password.Equals(model.Password)).FirstOrDefault();
                        if (obj != null)
                        {
                            FormsAuthentication.SetAuthCookie(obj.Username.ToString(), false);
                            Session["UserId"] = obj.Id.ToString();
                            Session["UserImage"] = obj.Image.ToString();
                            Session["UserName"] = obj.Username.ToString();
                            logger.Info("Login Successfully");
                            return this.RedirectToAction("Details");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Incorrect Username or Password");
                            return RedirectToAction("Register", "Home");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e.ToString());
            }
            return View(model);
        }

        public string ValidateUser(string userName, string password)
        {
            var obj = db.tbl_User.Where(x => x.Username.Equals(userName) && x.Password.Equals(password)).FirstOrDefault();
            if(obj != null)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
        public ActionResult Details()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}