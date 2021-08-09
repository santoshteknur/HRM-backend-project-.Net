using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayrollDLL;
using System.Data;

namespace ERP.Models

{
    //public partial class Employee
    //{
    //    public string EmpID { get; set; }
    //    public string Name { get; set; }
    //    public string Father_Name { get; set; }
    //    public string Mother_Name { get; set; }
    //    public System.DateTime DOB { get; set; }
    //    public string Gender { get; set; }
    //    public string Nationality { get; set; }
    //    public string Maritual_Status { get; set; }
    //    public string Mobile { get; set; }
    //    public string Email { get; set; }
    //    public string Present_Address { get; set; }
    //    public string Permanent_Address { get; set; }
    //    public string Designation { get; set; }
    //    public Nullable<decimal> Gross_Salary { get; set; }
    //    public string Attendence_Status { get; set; }
    //    public string Password { get; set; }

    //}

    //public class PayrollMain
    //{
    //    public string EmpID { get; set; }
    //    public string EmpClassID { get; set; }
    //    public string EmpClass { get; set; }
    //    public string Designation { get; set; }
    //    public string Password { get; set; }
    //}

    public class Deduction
    {
        public string EmpID{ get; set; }
        public int MedicalPremium { get; set; }
        public int ProvidentFund { get; set; }
        public int ProfessionalTax { get; set; }
        public int AttendanceDeduction { get; set; }
    }
    public class Allowance
    {
        public string EmpID { get; set; }
        public int HouseAllowance { get; set; }
        public int ConveyanceAllowance { get; set; }
        public int MedicalAllowance { get; set; }
        public int StatutoryBonus { get; set; }
        public int SupplementaryAllowance { get; set; }
    }

    public class PaySlip
    {
        public string EmpID { get; set; }
        public Decimal GrossSalary { get; set; }
        public int Deduction { get; set; }
        public int Allowance { get; set; }

        public Decimal TotalSalary { get; set; }
    }
    public class EmpDataRepository
    {
        public List<Employee> GetAllEmployees()
        {
            var com = new DaoComponent();
            var table = com.GetAllRecords();
            List<Employee> list = new List<Employee>();
            foreach (DataRow row in table.Rows)
            {
                var emp = new Employee
                {
                    EmpID = Convert.ToInt32(row[0]),
                    Name = row[1].ToString(),
                    Gender = row[2].ToString(),
                    DOB = Convert.ToDateTime(row[3]),
                    Joining_Date= Convert.ToDateTime(row[4]),
                    Nationality = row[5].ToString(),
                    Mobile = row[6].ToString(),
                    Email = row[7].ToString(),
                    Address = row[8].ToString(),
                    Department = row[9].ToString(),
                    Designation = row[10].ToString(),
                    Gross_Salary = Convert.ToInt32(row[11]),
                    

                };
                list.Add(emp);
            }
            return list;
        }
       

        //public Boolean ValidateLogin(string empId,string password)
        //{
        //    var con = new DaoComponent();
        //    DataRow row = con.ValidatePassword(empId);
        //    var emp = new PayrollMain
        //    {
        //        EmpID = row[0].ToString(),
        //        EmpClassID = row[1].ToString(),
        //        EmpClass=row[2].ToString(),
        //        Designation=row[3].ToString(),
        //        Password = row[4].ToString()
            
        //    };
        //    if ((emp.EmpID.Equals(empId)) && (emp.Password.Equals(password)))
        //    {
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        public Deduction getdeduction(int empid)
        {
            var con = new DaoComponent();
            DataRow row = con.getDeductions(empid);
            var d = new Deduction
            {
                EmpID = row[0].ToString(),
                MedicalPremium = Convert.ToInt32(row[1]),
                ProvidentFund =Convert.ToInt32(row[2]),
                ProfessionalTax = Convert.ToInt32(row[3]),
                AttendanceDeduction = Convert.ToInt32(row[4])
            };
            return d;
        }
        public Allowance getallowance(int empid)
        {
            var con = new DaoComponent();
            DataRow row = con.getAllowance(empid);
            var a = new Allowance
            {
                EmpID = row[0].ToString(),
                HouseAllowance= Convert.ToInt32(row[1]),
                ConveyanceAllowance = Convert.ToInt32(row[2]),
                MedicalAllowance = Convert.ToInt32(row[3]),
                StatutoryBonus = Convert.ToInt32(row[4]),
                SupplementaryAllowance = Convert.ToInt32(row[5])
            };
            return a;  
        }

        public PaySlip generatePaySlip(int empid)
        {
            var con = new DaoComponent();
            DataRow row = con.getDeductions(empid);
            var d = new Deduction
            {
                EmpID = row[0].ToString(),
                MedicalPremium = Convert.ToInt32(row[1]),
                ProvidentFund = Convert.ToInt32(row[2]),
                ProfessionalTax = Convert.ToInt32(row[3]),
                AttendanceDeduction = Convert.ToInt32(row[4])
            };

            int totalDeduction = d.MedicalPremium + d.ProfessionalTax + d.ProvidentFund + d.AttendanceDeduction;
            DataRow row1 = con.getAllowance(empid);
            var a = new Allowance
            {
                EmpID = row1[0].ToString(),
                HouseAllowance = Convert.ToInt32(row1[1]),
                ConveyanceAllowance = Convert.ToInt32(row1[2]),
                MedicalAllowance = Convert.ToInt32(row1[3]),
                StatutoryBonus = Convert.ToInt32(row1[4]),
                SupplementaryAllowance = Convert.ToInt32(row1[5])
            };

            int totalAllowance = a.HouseAllowance + a.MedicalAllowance + a.ConveyanceAllowance + a.StatutoryBonus + a.SupplementaryAllowance;
            DataRow data = con.getGrossSalary(empid);
            Employee emp = new Employee();
            emp.Gross_Salary = Convert.ToDecimal(data[11]);
            
            Decimal total = (Decimal)emp.Gross_Salary + totalAllowance - totalDeduction;

            var p = new PaySlip
            {
                EmpID = empid.ToString(),
                Allowance = totalAllowance,
                Deduction=totalDeduction,
                GrossSalary=(Decimal)emp.Gross_Salary,
                TotalSalary=total
            };

            return p;

        }
    }
}
