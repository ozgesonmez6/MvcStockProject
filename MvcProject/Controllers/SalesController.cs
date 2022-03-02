using MvcProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class SalesController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewSales()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewSales(Sales sales)
        {
            db.Sales.Add(sales);
            db.SaveChanges();
            return View("Index");
        }
    }
}