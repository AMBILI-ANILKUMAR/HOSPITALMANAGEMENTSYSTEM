using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOSPITALMANAGEMENTSYSTEM.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult AddSpecialization()
        {
            return View();
        }
        public ActionResult AddDoctor()
        {
            return View();
        }
    }
}