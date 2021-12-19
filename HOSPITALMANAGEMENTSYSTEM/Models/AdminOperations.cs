using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace HOSPITALMANAGEMENTSYSTEM.Models
{
    public class AdminOperations
    {
        List<Specializations> dlst = new List<Specializations>();
        SqlConnection con = null;
        public AdminOperations()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);
        }
        public bool AddSpecialization(Specializations s)
        {
            bool b = false;
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Specialization(specializationName)values(@sname)", con);
                cmd.Parameters.AddWithValue("@sname", s.specializationName);
                cmd.ExecuteNonQuery();
                b = true;
            }
            catch (Exception e)
            {
                b = false;
            }
            return b;
        }
        public IEnumerable<Specializations> GetSpclData()
        {
            SqlDataAdapter data = new SqlDataAdapter("Select * from Specialization order by spclId", con);
            DataSet ds = new DataSet();
            data.Fill(ds, "spcl");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Specializations s = new Specializations();
                s.spclId = int.Parse(ds.Tables[0].Rows[i]["spclId"].ToString());
                s.specializationName = ds.Tables[0].Rows[i]["specializationName"].ToString();
                dlst.Add(s);
            }
            return dlst;
        }
        public bool AddDoctors(Doctors d)
        {
            bool b = false;
            try
            {
                //create table Doctors(DoctId varchar(5) primary key,DoctName varchar(20),Gender varchar(10),Address varchar(50),phonenumber char(10),
                //age int, spclId int , foreign key(spclId) references Specialization, role varchar(10),email varchar(30),password varchar(10))
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Doctors(DoctId,DoctName,Gender,Address,phonenumber,age,spclId,role,email,password)values(@did ,@dname, @gen, @add, @pno, @age ,@sid ,@role,@em, @pwd)", con);
                cmd.Parameters.AddWithValue("@did", d.DoctId);
                cmd.Parameters.AddWithValue("@dname", d.DoctName);
                cmd.Parameters.AddWithValue("@gen", d.Gender);
                cmd.Parameters.AddWithValue("@add", d.Address);
                cmd.Parameters.AddWithValue("@pno", d.phonenumber);
                cmd.Parameters.AddWithValue("@age", d.age);
                cmd.Parameters.AddWithValue("@sid", d.spclId);
                cmd.Parameters.AddWithValue("@role", d.role);
                cmd.Parameters.AddWithValue("@em", d.email);
                cmd.Parameters.AddWithValue("@pwd", d.password);
                cmd.ExecuteNonQuery();
                b = true;
            }
            catch (Exception e)
            {
                b = false;
            }
            return b;
        }
        public bool AddPatients(Patients p)
        {
            bool b = false;
            
                //create table Doctors(DoctId varchar(5) primary key,DoctName varchar(20),Gender varchar(10),Address varchar(50),phonenumber char(10),
                //age int, spclId int , foreign key(spclId) references Specialization, role varchar(10),email varchar(30),password varchar(10))
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Patients(PatId,PatName,Gender,Address,phonenumber,age,bloodgrp,email,password)values(@pid ,@pname, @gen, @add, @pno, @age ,@bgrp ,@em, @pwd)", con);
                cmd.Parameters.AddWithValue("@pid", p.PatId);
                cmd.Parameters.AddWithValue("@pname", p.PatName);
                cmd.Parameters.AddWithValue("@gen", p.Gender);
                cmd.Parameters.AddWithValue("@add", p.Address);
                cmd.Parameters.AddWithValue("@pno", p.phonenumber);
                cmd.Parameters.AddWithValue("@age", p.age);
                cmd.Parameters.AddWithValue("@bgrp", p.bloodgrp);
                cmd.Parameters.AddWithValue("@em", p.email);
                cmd.Parameters.AddWithValue("@pwd", p.password);
                cmd.ExecuteNonQuery();
                b = true;
            
            return b;
        }
    }
}