using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication1.Models.siniflar;
namespace WebApplication1.Controllers
{
	public class AdminController : Controller
	{
		// GET: Admin
		Context c = new Context();
		public ActionResult Index()
		{
			var degerler = c.Blogs.ToList();
			return View(degerler);
		}
		[HttpGet]
		public ActionResult YeniBlog()
		{
			return View();
		}
		[HttpPost]

		public ActionResult YeniBlog(Blog p)
		{
			c.Blogs.Add(p);
			c.SaveChanges();
			return RedirectToAction("Index");

		}
		public ActionResult BlogSil(int id)
		{
			var b = c.Blogs.Find(id); // id ye göre bul ve b ye ATA
			c.Blogs.Remove(b);
			c.SaveChanges();
			return RedirectToAction("Index");

		}
		public ActionResult BlogGetir(int id)
		{
			var bl = c.Blogs.Find(id); // ID'ye göre veriyi bul

			// Blog bulunamazsa null gönder
			return View("BlogGetir", bl);
		}
		public ActionResult BlogGüncelle(Blog d)
		{
			var blg = c.Blogs.Find(d.ID); // ID'ye göre veriyi bul
			blg.Aciklama= d.Aciklama;
			blg.BlogImage= d.BlogImage;
			blg.Tarih= d.Tarih;
			blg.Baslik=d.Baslik;
			c.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}