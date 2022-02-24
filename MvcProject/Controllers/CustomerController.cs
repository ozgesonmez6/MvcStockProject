using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models.Entity;

namespace MvcProject.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = db.Customers.ToList();
            return View(values);
        }
    }
}