using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Performance.Models
{
    public class Perform
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public int Workingdays { get; set; }
        public int Present { get; set; }
        public double Percentage { get; set; }

    }
}