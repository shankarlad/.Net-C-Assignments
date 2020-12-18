using ModelBindingAndDbCode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBindingAndDbCode.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            using (JKDec20Entities jK = new JKDec20Entities())
            {
                return View(jK.Employees.ToList());
            }
            
            //List<Employee> ObjEmpList = new List<Employee>();
            //ObjEmpList.Add(new Employee { EmpNo = 101, Name = "Shankar", Basic = 45000, DeptNo = 10 });
            //ObjEmpList.Add(new Employee { EmpNo = 102, Name = "Bhushan", Basic = 40000, DeptNo = 20 });
            //ObjEmpList.Add(new Employee { EmpNo = 103, Name = "Gaurav", Basic = 35000, DeptNo = 20 });
            //ObjEmpList.Add(new Employee { EmpNo = 104, Name = "Phati", Basic = 45000, DeptNo = 30 });
            //ObjEmpList.Add(new Employee { EmpNo = 105, Name = "Avinash", Basic = 50000, DeptNo = 40 });

            //return View(ObjEmpList);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id = 0)
        {
            using (JKDec20Entities jK = new JKDec20Entities())
            {
                return View(jK.Employees.Where(x => x.EmpNo == id).FirstOrDefault());
            }

            //Employee objEmp = new Employee();
            //objEmp.EmpNo = 101;
            //objEmp.Name = "Shankar";
            //objEmp.Basic = 55000;
            //objEmp.DeptNo = 10;
            //return View(objEmp);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee objEmp)
        {
            try
            {
                // TODO: Add insert logic here
                using (JKDec20Entities jK = new JKDec20Entities())
                {
                    jK.Employees.Add(objEmp);
                    jK.SaveChanges();
                }


                //int EmpNo = objEmp.EmpNo;
                //string Name = objEmp.Name;
                //decimal Basic = objEmp.Basic;
                //int DeptNo = objEmp.DeptNo;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id = 0)
        {
            using (JKDec20Entities jK = new JKDec20Entities())
            {
                return View(jK.Employees.Where(x => x.EmpNo == id).FirstOrDefault());
            }

            //Employee objEmp = new Employee();
            //objEmp.EmpNo = 101;
            //objEmp.Name = "Shankar";
            //objEmp.Basic = 55000;
            //objEmp.DeptNo = 10;
            //return View(objEmp);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int ? id, Employee objEmp)
        {
            try
            {
                // TODO: Add update logic here

                using (JKDec20Entities jK = new JKDec20Entities())
                {
                    jK.Entry(objEmp).State = System.Data.Entity.EntityState.Modified;
                    jK.SaveChanges();
                }

                //int EmpNo = objEmp.EmpNo;
                //string Name = objEmp.Name;
                //decimal Basic = objEmp.Basic;
                //int DeptNo = objEmp.DeptNo;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id = 0)
        {
            using (JKDec20Entities jK = new JKDec20Entities())
            {
                return View(jK.Employees.Where(x => x.EmpNo == id).FirstOrDefault());
            }

            //Employee objEmp = new Employee();
            //objEmp.EmpNo = 101;
            //objEmp.Name = "Shankar";
            //objEmp.Basic = 55000;
            //objEmp.DeptNo = 10;
            //return View(objEmp);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee objEmp)
        {
            try
            {
                // TODO: Add delete logic here
                using (JKDec20Entities jK = new JKDec20Entities())
                {
                    objEmp = jK.Employees.Where(x => x.EmpNo == id).FirstOrDefault();
                    jK.Employees.Remove(objEmp);
                    jK.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
