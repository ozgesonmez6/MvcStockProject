using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models.Entity;

namespace MvcProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = db.Products.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewProduct()
        {
            List<SelectListItem> values = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text=i.CategoryName,
                                               Value=i.CategoryID.ToString()
                                           }).ToList();
            ViewBag.value = values;
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(Products products)
        {
            db.Products.Add(products);
            db.SaveChanges();
            return View();
        }
    }
}