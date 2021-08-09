using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Models;
using System.Net;
namespace ERP.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        public ActionResult Index()
        {
            return View(employeeBusinessLayer.EmployeeTable.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(FormCollection formCollection)
        {
            
                Employee employee = new Employee();
           // employee.EmpID = Convert.ToInt32(formCollection["EmpID"]);
            employee.Name = formCollection["Name"];
            employee.Address = formCollection["Address"];
            employee.Nationality = formCollection["Nationality"];
            employee.Department = formCollection["Department"];
            employee.Designation = formCollection["Designation"];
            employee.DOB = Convert.ToDateTime(formCollection["DOB"]);
            employee.Email = formCollection["Email"];
            employee.Gender = formCollection["Gender"];
            employee.Gross_Salary = Convert.ToDecimal(formCollection["Gross_Salary"]);
            employee.Joining_Date = Convert.ToDateTime(formCollection["Joining_Date"]);
            employee.Mobile = (formCollection["Mobile"]).ToString();
            
                employeeBusinessLayer.EmployeeTable.Add(employee);
                employeeBusinessLayer.SaveChanges();
           
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Employee Id Required");
            }
            Employee employee = employeeBusinessLayer.EmployeeTable.Find(id);
            if (employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Employee Not Found");
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            Employee employee = employeeBusinessLayer.EmployeeTable.Find(id);
            UpdateModel(employee);
            employeeBusinessLayer.EmployeeTable.Add(employee);
            employeeBusinessLayer.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Employee Id Required");
            }
            Employee employee = employeeBusinessLayer.EmployeeTable.Find(id);
            if (employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Employee Not Found");
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee employee = employeeBusinessLayer.EmployeeTable.Find(id);

            employeeBusinessLayer.EmployeeTable.Remove(employee);
            employeeBusinessLayer.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Employee Id Required");
            }
            Employee employee = employeeBusinessLayer.EmployeeTable.Find(id);
            if (employee == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Employee Not Found");
            }
            return View(employee);
        }
    }
}