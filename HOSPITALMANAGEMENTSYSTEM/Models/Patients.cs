using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        //public bgrp bloodgroup { get; set; }

        public string email { get; set; }
        public string password { get; set; }

    }
    public enum bgrp
    {
        [Display(Name = "A+")] APositive,
        [Display(Name = "A-")] ANegetive,
        [Display(Name = "B+")] BPositive,
        [Display(Name = "B-")] BNegetive,
        [Display(Name = "O+")] OPositive,
        [Display(Name = "O-")] ONegetive,
        [Display(Name = "AB+")] ABPositive,
        [Display(Name = "AB-")] ABNegetive,
    }
}