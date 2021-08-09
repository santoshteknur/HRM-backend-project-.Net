using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Performance.Models;
using Rotativa;

namespace Performance.Controllers
{
    public class PerformanceController : Controller
    {
        string connectionString = @"Data Source=DELL; Initial Catalog = Hrm; Integrated Security = True";
        public ActionResult Print()
        {
            var print = new ActionAsPdf("Detail");
            return print;
        }
        public ActionResult Detail()
        {
            DataTable dtblPerform = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM Performance", sqlcon);
                sqlda.Fill(dtblPerform);
            }
            return View(dtblPerform);
        }
        public ActionResult Index()
            {
                DataTable dtblPerform = new DataTable();
                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlda = new SqlDataAdapter("SELECT * FROM Performance", sqlcon);
                    sqlda.Fill(dtblPerform);
                }
                return View(dtblPerform);
            }
        public ActionResult Create()
        {
            return View(new Perform());
        }

        [HttpPost]
        public ActionResult Create(Perform p)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                string query = "INSERT INTO Performance VALUES (@Name,@Designation,@Workingdays,@Present,@Percentage)";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@Name", p.Name);
                sqlcmd.Parameters.AddWithValue("@Designation", p.Designation);
                sqlcmd.Parameters.AddWithValue("@Workingdays", p.Workingdays);
                sqlcmd.Parameters.AddWithValue("@Present", p.Present);
                sqlcmd.Parameters.AddWithValue("@Percentage", p.Percentage);
                sqlcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Perform perform = new Perform();
            DataTable dtblPerform = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                string query = "SELECT * FROM Performance where EmpID = @EmpID";
                SqlDataAdapter sqlda = new SqlDataAdapter(query, sqlcon);
                sqlda.SelectCommand.Parameters.AddWithValue("EmpID", id);
                sqlda.Fill(dtblPerform);
            }
            if (dtblPerform.Rows.Count == 1)
            {
                perform.EmpID = Convert.ToInt32(dtblPerform.Rows[0][0].ToString());
                perform.Name = (dtblPerform.Rows[0][1].ToString());
                perform.Designation = (dtblPerform.Rows[0][2].ToString());
                perform.Workingdays = Convert.ToInt32(dtblPerform.Rows[0][3].ToString());
                perform.Present = Convert.ToInt32(dtblPerform.Rows[0][4].ToString());
                perform.Percentage = Convert.ToDouble(dtblPerform.Rows[0][5].ToString());
                return View(perform);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Perform perform)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                string query = "UPDATE Performance SET Name = @Name, Designation = @Designation, Workingdays = @Workingdays, Present = @Present, Percentage = @Percentage where EmpID = @EmpID";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@EmpID", perform.EmpID);
                sqlcmd.Parameters.AddWithValue("@Name", perform.Name);
                sqlcmd.Parameters.AddWithValue("@Designation", perform.Designation);
                sqlcmd.Parameters.AddWithValue("@Workingdays", perform.Workingdays);
                sqlcmd.Parameters.AddWithValue("@Present", perform.Present);
                sqlcmd.Parameters.AddWithValue("@Percentage", perform.Percentage);
                sqlcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                string query = "DELETE FROM Performance where EmpID = @EmpID";
                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@EmpID", id);
                sqlcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
