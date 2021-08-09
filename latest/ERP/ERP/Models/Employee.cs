using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ERP.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }

        public string Name { get; set; }

        public DateTime Joining_Date { get; set; }

        public DateTime DOB { get; set; }
        public string Gender { get; set; }

        public string Nationality { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }
       
        public string Address { get; set; }
        
        public string Department { get; set; }
        
        public string Designation { get; set; }

        public decimal Gross_Salary { get; set; }


    }
    //public class Employee
    //{
    //    [Key]
    //    public int EmpID { get; set; }

    //    [Required(ErrorMessage ="Employee Name Required")]
    //    public string Name { get; set; }

    //    [Required(ErrorMessage ="Joining Date Required")]
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString ="0:dd/mm/yyyy")]
    //    public DateTime Joining_Date { get; set; }

    //    [Required(ErrorMessage ="DOB Required")]
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString ="0:dd/mm//yyyy")]
    //    public Nullable<System.DateTime> DOB { get; set; }
    //    public string Gender { get; set; }

    //    [Required(ErrorMessage ="Please select nationality")]
    //    public string Nationality { get; set; }

    //    [Required(ErrorMessage ="Enter a valid mobile no.")]
    //    //[StringLength(10)]
    //    [DataType(DataType.PhoneNumber)]
    //    [RegularExpression(@"\[6-9][0-9]{9}",ErrorMessage ="Invalid Mobile no.")]

    //    public string Mobile { get; set; }

    //    [Required(ErrorMessage ="Email Required")]
    //    [DataType(DataType.EmailAddress,ErrorMessage ="Invalid Email")]
    //    public string Email { get; set; }
    //    [Required(ErrorMessage ="Address Required")]
    //    public string Address { get; set; }
    //    [Required(ErrorMessage = "Please select Department")]
    //    public string Department { get; set; }
    //    [Required(ErrorMessage = "Please select Designation")]
    //    public string Designation { get; set; }


    //    public double Gross_Salary { get; set; }


    //}
}