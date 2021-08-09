using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PayrollDLL
{
    public class DaoComponent
    {
        const string STRCONNECTION = @"Data Source=DELL;Initial Catalog=Hrm;Integrated Security=True;User ID=sa;Password=***********";
        const string STRSELECT = "SELECT * FROM Employee";
        //const string STRVALIDATE = "SELECT * from PayrollMain where EmpID=@id";
        const string STRGROSS = "SELECT * From Employee where EmpID=@id";
        const string STRDEDUCT = "SELECT * From Deduction where EmpID=@id";
        const string STRALLOWANCE = "SELECT * From Allowance1 where EmpID=@id";
        const string STRGROSSSALARY = "SELECT Gross_Salary from Employee where EmpID=@id";

        
        public DataTable GetAllRecords()
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRSELECT, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable instance = new DataTable();
                instance.Load(reader);
                return instance;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        //public DataRow ValidatePassword(string id)
        //{
        //    SqlConnection con = new SqlConnection(STRCONNECTION);
        //    SqlCommand cmd = new SqlCommand(STRVALIDATE, con);
        //    cmd.Parameters.AddWithValue("@id", id);
        //    try
        //    {
        //        con.Open();
        //        var reader = cmd.ExecuteReader();
        //        DataTable instance = new DataTable();
        //        instance.Load(reader);
        //        return instance.Rows[0];
        //    }catch(SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        public DataRow getGrossSalary(int id)
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRGROSS, con);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable instance = new DataTable();
                instance.Load(reader);
                return instance.Rows[0];
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        
        public DataRow getDeductions(int id)
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRDEDUCT, con);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                return table.Rows[0];
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        public DataRow getAllowance(int id)
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(STRALLOWANCE, con);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                return table.Rows[0];
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

   
        



    }
}

