using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HOSPITALMANAGEMENTSYSTEM.Models
{
    public class Appointments
    {
        public string AppointmentId { get; set; }
        public string PatId { get; set; }
        public string DoctId { get; set; }
        public string disease { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] 
        public DateTime Date { get; set; }
        public string AppTime { get; set; }
        
        public int spclId { get; set; }
        public string diagnosis { get; set; }
        [NotMapped]
        public SelectList PatDropdown { get; set; }
        [NotMapped]
        public SelectList DocDropdown { get; set; }
    }
    public enum apointtym
    {

        [Display(Name = "9AM - 12PM")] nineamto12pm,
        [Display(Name = "2PM - 4PM")] twopmto4pm,
        [Display(Name = "5PM - 6PM")] fivepmto6pm,

    }
}