using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace HOSPITALMANAGEMENTSYSTEM.Models
{
    public class DoctorOperations
    {
        SqlConnection con = null;
        public DoctorOperations()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        }
        public DataSet logincheck(string uname, string pwd)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter madpt = new SqlDataAdapter("select * from Doctors where email='" + uname + "' and password='" + pwd + "'", con);
                madpt.Fill(ds, "doc");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return ds;
        }
        public DataSet ViewAppointment(string id)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter adpt = new SqlDataAdapter("select * from Appointments as a inner join Doctors as d on a.DoctId=d.DoctId inner join Patients as p on a.PatId=p.PatId where a.DoctId='" + id + "'", con);
                adpt.Fill(ds, "apt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ds;
        }
        public DataSet ViewPrescription(string id,string aid)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter adpt = new SqlDataAdapter("select * from Appointments as a inner join Doctors as d on a.DoctId=d.DoctId inner join Patients as p on a.PatId=p.PatId inner join Prescriptions as pr on pr.AppointmentId=a.AppointmentId where a.DoctId='"+id+ "' and a.AppointmentId='"+aid+"'", con);
                adpt.Fill(ds, "apt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ds;
        }
        
        public bool AddPrescription(Appointments a)
        {
            bool b = false;
            try
            {
                //create table Appointments(AppointmentId varchar(10) primary key, PatId varchar(5),foreign key(PatId) references Patients,DoctId varchar(5),foreign key(DoctId) references Doctors,
                //disease varchar(50),AppDate date)
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Prescriptions (AppointmentId,diagnosis,medicine) values (@aid,@dia,@med)", con);
                cmd.Parameters.AddWithValue("@aid", a.AppointmentId);
                cmd.Parameters.AddWithValue("@dia", a.diagnosis);
                cmd.Parameters.AddWithValue("@med", a.medicine);                
                cmd.ExecuteNonQuery();
                b = true;
            }
            catch (Exception ex)
            {
                b = false;
            }

            return b;
        }
    }

}