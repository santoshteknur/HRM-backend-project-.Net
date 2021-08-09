using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Models;

namespace MVC.Controllers
{
    
    public class PayRollController : Controller
    {
        // GET: Employee
        public ViewResult EmpDetail()
        {
            var com = new ERP.Models.EmpDataRepository();
            var table = com.GetAllEmployees();
            return View(table);//Model is DataTable...
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Deduction(int id)
        {
            var con = new EmpDataRepository();
            Deduction d = con.getdeduction(id);
            return View(d);
        }
        public ActionResult Allowance(int id)
        {
            var con = new EmpDataRepository();
            Allowance d = con.getallowance(id);
            return View(d);
        }

        public ActionResult showPaySlip(int id)
        {
            var con = new EmpDataRepository();
            PaySlip p = con.generatePaySlip(id);
            return View(p);
        }



    }
}