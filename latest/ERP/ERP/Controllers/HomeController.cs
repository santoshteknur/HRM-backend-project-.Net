using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERP.Models;

namespace ERP.Controllers
{
    public class HomeController : Controller
    {
        Signupbussinesslayer signupbussinesslayer = new Signupbussinesslayer();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(FormCollection formCollection)
        {
            SignUpDetails signUpDetails = new SignUpDetails();

            signUpDetails.firstName = formCollection["firstName"];
            signUpDetails.lastName = formCollection["lastName"];
            signUpDetails.email = formCollection["email"];
            signUpDetails.password = formCollection["password"];
            signUpDetails.confirm_password = formCollection["confirm_password"];


            signupbussinesslayer.SignUpDetailsTable.Add(signUpDetails);
            signupbussinesslayer.SaveChanges();

            return RedirectToAction("Login");
            
        }
        
        

        public ActionResult Home()
        {
            return View();
        }
    }
}