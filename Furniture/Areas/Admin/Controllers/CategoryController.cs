using Furniture.Models;
using Furniture.Models.Context;
using Furniture.Models.Common;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Furniture.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = dbConnect.categories.ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if(ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                //model.Position = 1;
                model.Alias = Furniture.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.categories.Add(model);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = dbConnect.categories.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                dbConnect.categories.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = Furniture.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.Entry(model).Property(x => x.Title).IsModified = true;
                dbConnect.Entry(model).Property(x => x.C_Description).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Alias).IsModified = true;
                dbConnect.Entry(model).Property(x => x.SeoDescription).IsModified = true;
                dbConnect.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                dbConnect.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                dbConnect.Entry(model).Property(x => x.Position).IsModified = true;
                dbConnect.Entry(model).Property(x => x.ModifiedDate).IsModified = true;
                dbConnect.Entry(model).Property(x => x.ModifiedBy).IsModified = true;
                dbConnect.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }
    }
}