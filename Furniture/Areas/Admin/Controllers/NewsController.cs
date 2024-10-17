using Furniture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Furniture.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Admin/News
        public ActionResult Index()
        {
            var item = dbContext.news.OrderByDescending(x => x.News_ID).ToList();
            return View(item);
        }
        public ActionResult Add()
        {
            return View();
        }
    }
}