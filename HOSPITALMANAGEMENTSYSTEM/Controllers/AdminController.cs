using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HOSPITALMANAGEMENTSYSTEM.Models;
namespace HOSPITALMANAGEMENTSYSTEM.Controllers
{
    public class AdminController : Controller
    {
        AdminOperations aop = new AdminOperations();
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
        [HttpPost]
        public ActionResult AddSpecialization(Specializations s)
        {
            bool b = aop.AddSpecialization(s);
            if (b == true)
                ViewBag.info = "Added Successfully";
            return View();
        }
        public ActionResult AddDoctor()
        {
            Doctors d = new Doctors();
            d.SpclDropdown = new SelectList(aop.GetSpclData(), "spclId", "specializationName");
            return View(d);
        }
        [HttpPost]
        public ActionResult AddDoctor(Doctors d)
        {
            bool b = aop.AddDoctors(d);
            if (b == true)
            {
                d.SpclDropdown = new SelectList(aop.GetSpclData(), "spclId", "specializationName");
                ViewBag.info = "Added Successfully";
            }
            else
            {
                d.SpclDropdown = new SelectList(aop.GetSpclData(), "spclId", "specializationName");
            }
            return View(d);
        }
        public ActionResult AddPatient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPatient(Patients p)
        {
            if (p.bloodgrp == "0")
                p.bloodgrp = "A+";
            else if(p.bloodgrp=="1")
                p.bloodgrp = "A-";
            else if (p.bloodgrp == "2")
                p.bloodgrp = "B+";
            else if (p.bloodgrp == "3")
                p.bloodgrp = "B-";
            else if (p.bloodgrp == "4")
                p.bloodgrp = "O+";
            else if (p.bloodgrp == "5")
                p.bloodgrp = "0-";
            else if (p.bloodgrp == "6")
                p.bloodgrp = "AB+";
            else if (p.bloodgrp == "7")
                p.bloodgrp = "AB-";
            bool b = aop.AddPatients(p);
            if (b == true)
            {
                ViewBag.info = "Added Successfully";
            }
           return View(p);
        }
    }
}