using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOSPITALMANAGEMENTSYSTEM.Models;
namespace HOSPITALMANAGEMENTSYSTEM.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        
        
        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Login l)
        {
            if (l.Username == "admin" && l.Password == "admin")
            {
                return RedirectToAction("AdminHome", "Admin");
            }
            else
            {
                ViewBag.info = "Please Check the credentials";
            }
            return View();
        }
        public ActionResult DoctorLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoctorLogin(Login l)
        {
            return View();
        }
        public ActionResult PatientLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PatientLogin(Login l)
        {
            return View();
        }
    }
}