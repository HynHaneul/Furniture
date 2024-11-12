using Furniture.Models;
using Furniture.Models.Context;
using NUnit.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Furniture.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext dbConnect = new ApplicationDbContext();
        // GET: Admin/post
        public ActionResult Index(string searchText, int? page)
        {
            int pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Post> items = dbConnect.posts.OrderByDescending(x => x.Posts_ID);
            if (!string.IsNullOrEmpty(searchText))
            {
                items = items.Where(x => x.Alias.Contains(searchText) || x.Title.Contains(searchText));
            }
            int pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
                items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedDate = DateTime.Now;
                post.ModifiedDate = DateTime.Now;
                post.Alias = Furniture.Models.Common.Filter.FilterChar(post.Title);
                dbConnect.posts.Add(post);
                dbConnect.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }
        public ActionResult Edit(int id)
        {
            var item = dbConnect.posts.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post model)
        {
            if (ModelState.IsValid)
            {
                dbConnect.posts.Attach(model);
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
            var item = dbConnect.posts.Find(id);
            if (item != null)
            {
                dbConnect.posts.Remove(item);
                dbConnect.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        public ActionResult IsActive(int id)
        {
            var item = dbConnect.posts.Find(id);
            if (item != null)
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
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = dbConnect.posts.Find(Convert.ToInt32(item));
                        dbConnect.posts.Remove(obj);
                        dbConnect.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}