using Furniture.Models;
using Furniture.Models.Context;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                model.Position = 1;
                dbConnect.categories.Add(model);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }
    }
}