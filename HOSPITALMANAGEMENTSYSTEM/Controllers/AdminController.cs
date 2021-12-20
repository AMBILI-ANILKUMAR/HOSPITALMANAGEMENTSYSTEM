﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using HOSPITALMANAGEMENTSYSTEM.Models;
namespace HOSPITALMANAGEMENTSYSTEM.Controllers
{
    public class AdminController : Controller
    {
        AdminOperations aop = new AdminOperations();
        List<Specializations> slst = new List<Specializations>();
        List<Doctors> dlst = new List<Doctors>();
        List<Patients> plst = new List<Patients>();
        List<Appointments> alst = new List<Appointments>();


        // GET: Admin
        public ActionResult AdminLogin()
        {
            return View();
        }
        public ActionResult Appointment()
        {
            return View();
        }
        public ActionResult Specialization()
        {
            return View();
        }
        public ActionResult Doctor()
        {
            return View();
        }
        public ActionResult Patient()
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
            {
                ViewBag.info = "Added Successfully";
                return RedirectToAction("ViewSpecialization");
            }
            return View();
        }
        public ActionResult ViewSpecialization()
        {

            DataSet ds = aop.ViewSpecialization();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Specializations c = new Specializations();
                c.spclId = int.Parse(ds.Tables[0].Rows[i]["spclId"].ToString());
                c.specializationName = ds.Tables[0].Rows[i]["specializationName"].ToString();
                slst.Add(c);
            }
            return View(slst);

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
                return RedirectToAction("ViewDoctor");
            }
            else
            {
                d.SpclDropdown = new SelectList(aop.GetSpclData(), "spclId", "specializationName");
            }
            return View(d);
        }
        public ActionResult ViewDoctor()
        {

            DataSet ds = aop.ViewDoctor();
            if ((ds.Tables["doc"].Rows.Count > 0))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Doctors d = new Doctors();
                    d.DoctId = ds.Tables[0].Rows[i]["DoctId"].ToString();
                    d.DoctName = ds.Tables[0].Rows[i]["DoctName"].ToString();
                    d.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                    d.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                    d.phonenumber = ds.Tables[0].Rows[i]["phonenumber"].ToString();
                    d.age = int.Parse(ds.Tables[0].Rows[i]["age"].ToString());
                    d.specializationName = ds.Tables[0].Rows[i]["specializationName"].ToString();
                    d.email = ds.Tables[0].Rows[i]["email"].ToString();
                    d.password = ds.Tables[0].Rows[i]["password"].ToString();

                    dlst.Add(d);
                }
                return View(dlst);
            }
            else
            {
                ViewBag.info = "No Doctors Added Yet!";
                return View(dlst);
            }
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
            else if (p.bloodgrp == "1")
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
                return RedirectToAction("ShowPatient");
            }
            return View(p);
        }
        public ActionResult ShowPatient()
        {
            DataSet ds = aop.ShowPatient();
            if ((ds.Tables["pat"].Rows.Count > 0))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Patients d = new Patients();
                    d.PatId = ds.Tables[0].Rows[i]["PatId"].ToString();
                    d.PatName = ds.Tables[0].Rows[i]["PatName"].ToString();
                    d.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
                    d.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                    d.phonenumber = ds.Tables[0].Rows[i]["phonenumber"].ToString();
                    d.age = int.Parse(ds.Tables[0].Rows[i]["age"].ToString());
                    d.bloodgrp = ds.Tables[0].Rows[i]["bloodgrp"].ToString();
                    d.email = ds.Tables[0].Rows[i]["email"].ToString();
                    d.password = ds.Tables[0].Rows[i]["password"].ToString();
                    plst.Add(d);
                }
                return View(plst);
            }
            else
            {
                ViewBag.info = "No Patients Added Yet!";
                return View(plst);
            }
        }
        public ActionResult AddAppointments()
        {
            Appointments a = new Appointments();
            a.DocDropdown = new SelectList(aop.GetDocData(), "DoctId", "DoctName");
            a.PatDropdown = new SelectList(aop.GetPatData(), "PatId", "PatName");
            return View(a);
        }
        [HttpPost]
        public ActionResult AddAppointments(Appointments a)
        {
            if (a.AppTime == "0")
                a.AppTime = "9AM - 12PM";
            else if(a.AppTime == "1")
                a.AppTime = "2PM - 4PM";
            else
                a.AppTime = "5PM - 6PM";

            bool b = aop.AddAppointment(a);
            if(b==true)
            {
                a.DocDropdown = new SelectList(aop.GetDocData(), "DoctId", "DoctName");
                a.PatDropdown = new SelectList(aop.GetPatData(), "PatId", "PatName");
                ViewBag.info = "Added Successfully";
                return RedirectToAction("ViewAppointment");

            }
            else
            {
                a.DocDropdown = new SelectList(aop.GetDocData(), "DoctId", "DoctName");
                a.PatDropdown = new SelectList(aop.GetPatData(), "PatId", "PatName");
                ViewBag.info = "Not Added";

            }
            return View(a);
        }
        public ActionResult ViewAppointment()
        {
            DataSet ds = aop.ViewAppointment();
            if ((ds.Tables["apt"].Rows.Count > 0))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Appointments d = new Appointments();
                    d.AppointmentId= ds.Tables[0].Rows[i]["AppointmentId"].ToString();
                    d.PatId = ds.Tables[0].Rows[i]["PatId"].ToString();
                    d.DoctId = ds.Tables[0].Rows[i]["DoctId"].ToString();
                    d.disease = ds.Tables[0].Rows[i]["disease"].ToString();
                    d.Date =DateTime.Parse( ds.Tables[0].Rows[i]["AppDate"].ToString());
                    d.AppTime = (ds.Tables[0].Rows[i]["AppTime"].ToString());
                    alst.Add(d);
                }
                return View(alst);
            }
            else
            {
                ViewBag.info = "No Appointments Added Yet!";
                return View(alst);
            }
        }
    }
}