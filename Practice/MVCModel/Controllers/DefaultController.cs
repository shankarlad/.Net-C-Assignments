using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCModel.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View();
        }

        public ActionResult First(int id=0)
        {
            ViewBag.Id = id;
            return View();
        }
        public ActionResult Second(int id = 0,int a = 0,int b = 0,string c = "")
        {
            ViewBag.Id = id;
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;
            return View();
        }

        //public string Method1()
        //{
        //    return "Hello <b>World<b>";
        //}
    }
}