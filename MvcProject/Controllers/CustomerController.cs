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
        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCustomer(Customers customers)
        {
            db.Customers.Add(customers);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCustomer(int id)
        {
            var customer = db.Customers.Find(id);
            return View("GetCustomer", customer);
        }

        public ActionResult Update(Customers customers)
        {
            var customer = db.Customers.Find(customers.CustomerID);
            customer.CustomerName = customers.CustomerName;
            customer.CustomerLastname = customers.CustomerLastname;
            db.SaveChanges();
            return RedirectToAction("Index");
       
        }

    }
}