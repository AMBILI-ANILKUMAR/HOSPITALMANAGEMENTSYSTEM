using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult DoctorLogin()
        {
            return View();
        }
        public ActionResult PatientLogin()
        {
            return View();
        }
    }
}