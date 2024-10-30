using Furniture.Models;
using Furniture.Models.Context;
using NUnit.Framework;
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
        public ActionResult Add(News news)
        {
            if (ModelState.IsValid)
            {
                news.CreatedDate = DateTime.Now;
                news.ModifiedDate = DateTime.Now;
                news.Alias = Furniture.Models.Common.Filter.FilterChar(news.Title);
                dbConnect.news.Add(news);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }
        public ActionResult Edit(int id)
        {
            var item = dbConnect.news.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News model)
        {
            if (ModelState.IsValid)
            {
                dbConnect.news.Attach(model);
                model.ModifiedDate = DateTime.Now;
                model.Alias = Furniture.Models.Common.Filter.FilterChar(model.Title);
                dbConnect.Entry(model).State = EntityState.Modified;
                dbConnect.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }
        [HttpPost]

        public ActionResult Delete(int id)
        
        {
            var item = dbConnect.news.Find(id);
            if(item != null)
            {
                dbConnect.news.Remove(item);
                dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success  = false});
        }
        public ActionResult IsActive(int id)
        {
            var item = dbConnect.news.Find(id);
            if(item != null)
            {
                item.IsActive = !item.IsActive;
                dbConnect.Entry(item).State = System.Data.Entity.EntityState.Modified;
                dbConnect.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult deleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if(items !=  null && items.Any())
                {
                    foreach(var item in items)
                    {
                        var obj = dbConnect.news.Find(Convert.ToInt32(item));    
                        dbConnect.news.Remove(obj);
                        dbConnect.SaveChanges ();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false});
        }
    }
}