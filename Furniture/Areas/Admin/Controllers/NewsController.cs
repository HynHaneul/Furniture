using Furniture.Models;
using Furniture.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Furniture.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Admin/News
        public ActionResult Index()
        {
            var items = dbConnect.news.OrderByDescending(x => x.News_ID).ToList();
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(News model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = Furniture.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.news.Add(model);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}