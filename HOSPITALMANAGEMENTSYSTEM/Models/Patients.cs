using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOSPITALMANAGEMENTSYSTEM.Models
{
    public class Patients
    {
        public string PatId { get; set; }
        public string PatName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string phonenumber { get; set; }
        public int age { get; set; }
        public string bloodgrp { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}