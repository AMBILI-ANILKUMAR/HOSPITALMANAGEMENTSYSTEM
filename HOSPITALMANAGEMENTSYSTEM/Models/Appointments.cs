using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOSPITALMANAGEMENTSYSTEM.Models
{
    public class Appointments
    {
        public string AppointmentId { get; set; }
        public string PatId { get; set; }
        public string DoctId { get; set; }
        public string disease { get; set; }
        public string AppDate { get; set; }
        public string fromtime { get; set; }
        public string totime { get; set; }
        public int spclId { get; set; }
        public string diagnosis { get; set; }
    }
}