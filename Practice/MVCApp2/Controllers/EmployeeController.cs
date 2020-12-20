using MVCApp2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp2.Controllers
{
    public class EmployeeController : Controller
    {
        private SqlConnection cn = new SqlConnection();

        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> emplist = new List<Employee>();

            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True";
               cn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Employees", cn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                emplist.Add(new Employee { EmpNo = (int)dr["EmpNo"], Name = (string)dr["Name"], Basic = (decimal)dr["Basic"], DeptNo = (int)dr["DeptNo"] });
            }
            cn.Close();
            return View(emplist);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int EmpNo = 0)
        {
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True";
            cn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Employees where EmpNo = " + EmpNo, cn);

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            Employee emp = new Employee { EmpNo = (int)dr["EmpNo"], Name = (string)dr["Name"], Basic = (decimal)dr["Basic"], DeptNo = (int)dr["DeptNo"] };

            cn.Close();

           

           
            return View(emp);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True";

            Employee emp = new Employee();
            cn.Open();
            List<SelectListItem> objDepts = new List<SelectListItem>();
            SqlCommand cmd1 = new SqlCommand("Select * from Department", cn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                objDepts.Add(new SelectListItem { Text = dr1["DeptName"].ToString(), Value = dr1["DeptNo"].ToString() });
            }


            emp.Department = objDepts;

            cn.Close();

            return View(emp);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                // TODO: Add insert logic here
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True;";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertEmployee";

                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int EmpNo = 0)
        {
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True";
            cn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Employees where EmpNo = " + EmpNo, cn);

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            Employee emp = new Employee { EmpNo = (int)dr["EmpNo"], Name = (string)dr["Name"], Basic = (decimal)dr["Basic"], DeptNo = (int)dr["DeptNo"] };
            cn.Close();
        
            cn.Open();
            List<SelectListItem> objDepts = new List<SelectListItem>();
            SqlCommand cmd1 = new SqlCommand("Select * from Department", cn);
            SqlDataReader dr1 = cmd1.ExecuteReader();
           while(dr1.Read())
            {
                objDepts.Add(new SelectListItem { Text=dr1["DeptName"].ToString(),Value=dr1["DeptNo"].ToString() });
            }


            emp.Department = objDepts;

            cn.Close();

            return View(emp);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int ? EmpNo, Employee emp)
        {
            try
            {
                // TODO: Add update logic here
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True;";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEmployee";

                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int EmpNo = 0)
        {
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True";
            cn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Employees where EmpNo = " + EmpNo, cn);

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            Employee emp = new Employee { EmpNo = (int)dr["EmpNo"], Name = (string)dr["Name"], Basic = (decimal)dr["Basic"], DeptNo = (int)dr["DeptNo"] };

            cn.Close();

            return View(emp);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int ? EmpNo, Employee emp)
        {
            try
            {
                // TODO: Add delete logic here
                cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteEmployee";

                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);


                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
