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
        [Required(ErrorMessage = "Patient Id is required")]
        public string PatId { get; set; }

        [Required(ErrorMessage = "Patient Name is required")]
        public string PatName { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phonenumber is required")]
        public string phonenumber { get; set; }

        [Required(ErrorMessage = "Age must be required")]
        public int age { get; set; }

        [Required(ErrorMessage = "Bloodgroup must be required")]
        public string bloodgrp { get; set; }
        //public bgrp bloodgroup { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
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