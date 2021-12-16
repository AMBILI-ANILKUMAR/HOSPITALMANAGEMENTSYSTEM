using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOSPITALMANAGEMENTSYSTEM.Models
{
    public class Doctors
    {
        public string DoctId { get; set; }
        public string DoctName { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string phonenumber { get; set; }

        public int age { get; set; }

        public int spclId { get; set; }

        public string role { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    }
}