using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class HRMController : Controller
    {
        // GET: HRM
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployeeLeave ()
        {
            return View();
        }
        public ActionResult EmployeeAttendance()
        {
            return View();
        }
        public ActionResult EmployeeReg()
        {
            return View();
        }
    }
}