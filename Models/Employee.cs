using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Attendance.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public int EMP_ID { get; set; }
        public string EMP_Name { get; set; }
        public DateTime Attend_Date { get; set; }
        public DateTime Local_InTime { get; set; }
        public DateTime Local_OutTime { get; set; }
    }
}