using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.siniflar;

namespace WebApplication1.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
		BlogYorum by = new BlogYorum();

		public ActionResult Index()
        {
            //var bloglar = c.Blogs.ToList();
            by.Deger1=c.Blogs.ToList();
			by.Deger3 = c.Blogs.Take(3).ToList();
			by.Deger1 = c.Blogs.Take(3).ToList();
			return View(by);
        }
		public ActionResult BlogDetay(int id)
        {
            //var blogbul = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger1=c.Blogs.Where(x => x.ID  ==id).ToList();
            by.Deger2=c.Yorumlars.Where(x => x.Blogid == id).ToList();
            by.Deger3= c.Blogs.Where(x => x.ID == id).ToList();

            return View(by);
        }
    }
}