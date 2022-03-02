using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProject.Models.Entity;
using PagedList;

namespace MvcProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int page=1)
        {
            var values = db.Categories.ToList().ToPagedList(page,4);
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
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.Categories.Add(categories);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCategory(int id)
        {
            var category = db.Categories.Find(id);
            return View("GetCategory", category);
        }

        public ActionResult Update(Categories categories)
        {
            var category = db.Categories.Find(categories.CategoryID);
            category.CategoryName = categories.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}