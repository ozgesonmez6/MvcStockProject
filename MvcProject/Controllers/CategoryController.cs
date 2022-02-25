using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models.Entity;

namespace MvcProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var values = db.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCategory(Categories categories)
        {
            db.Categories.Add(categories);
            db.SaveChanges();
            return View();
        }
    }
}