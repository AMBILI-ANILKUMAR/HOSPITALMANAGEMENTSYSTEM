using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using HOSPITALMANAGEMENTSYSTEM.Models;
namespace HOSPITALMANAGEMENTSYSTEM.Controllers
{
    public class DoctorController : Controller
    {
        DoctorOperations dop = new DoctorOperations();
        List<Appointments> alst = new List<Appointments>();
        List<Appointments> plst = new List<Appointments>();

        // GET: Doctor
        public ActionResult DoctorHome()
        {
            ViewBag.name = Session["name"];
            ViewBag.id ="Employee ID:"+Session["id"];
            return View();
        }
        public ActionResult Appointments()
        {
            string id = (string)Session["id"];
            DataSet ds = dop.ViewAppointment(id);
            if ((ds.Tables["apt"].Rows.Count > 0))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Appointments d = new Appointments();
                    d.AppointmentId = ds.Tables[0].Rows[i]["AppointmentId"].ToString();
                    d.PatName = ds.Tables[0].Rows[i]["PatName"].ToString();
                    d.DoctName = ds.Tables[0].Rows[i]["DoctName"].ToString();
                    d.disease = ds.Tables[0].Rows[i]["disease"].ToString();
                    d.Date = DateTime.Parse(ds.Tables[0].Rows[i]["AppDate"].ToString());
                    d.AppTime = (ds.Tables[0].Rows[i]["AppTime"].ToString());
                    alst.Add(d);
                }
                ViewBag.name = Session["name"];
                ViewBag.id = "Employee ID:" + Session["id"];
                return View(alst);

            }
            else
            {
                ViewBag.info = "No Appointments Added Yet!";
                ViewBag.name = Session["name"];
                ViewBag.id = "Employee ID:" + Session["id"];
                return View(alst);
            }
        }
        public ActionResult Prescription(string id)
        {
            string did = (string)Session["id"];
            DataSet ds = dop.ViewPrescription(did,id);
            if ((ds.Tables["apt"].Rows.Count == 0))
            {

                ViewBag.info = "No PrescriptionYet!";
                ViewBag.name = Session["name"];
                ViewBag.id = "Employee ID:" + Session["id"];
                return View(plst);


            }
            else
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Appointments d = new Appointments();
                    d.AppointmentId = ds.Tables[0].Rows[i]["AppointmentId"].ToString();
                    d.PatName = ds.Tables[0].Rows[i]["PatName"].ToString();
                    d.disease = ds.Tables[0].Rows[i]["disease"].ToString();
                    d.Date = DateTime.Parse(ds.Tables[0].Rows[i]["AppDate"].ToString());
                    d.AppTime = (ds.Tables[0].Rows[i]["AppTime"].ToString());
                    d.diagnosis = ds.Tables[0].Rows[i]["diagnosis"].ToString();
                    d.medicine = ds.Tables[0].Rows[i]["medicine"].ToString();
                    plst.Add(d);
                }
                ViewBag.name = Session["name"];
                ViewBag.id = "Employee ID:" + Session["id"];
                return View(plst);
            }
        }
        public ActionResult AddPrescription(string id)
        {
            ViewBag.name = Session["name"];
            ViewBag.id = "Employee ID:" + Session["id"];
            string did = (string)Session["id"];
            Appointments d = new Appointments();
            DataSet ds = dop.ViewPrescription(did,id);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                d.AppointmentId = ds.Tables[0].Rows[i]["AppointmentId"].ToString();
                d.PatName = ds.Tables[0].Rows[i]["PatName"].ToString();
                d.disease = ds.Tables[0].Rows[i]["disease"].ToString();
                d.Date = DateTime.Parse(ds.Tables[0].Rows[i]["AppDate"].ToString());
                d.AppTime = (ds.Tables[0].Rows[i]["AppTime"].ToString());
                d.diagnosis = ds.Tables[0].Rows[i]["diagnosis"].ToString();
                d.medicine = ds.Tables[0].Rows[i]["medicine"].ToString();
            }
            return View(d);
        }


    }
}