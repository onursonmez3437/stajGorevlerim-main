using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication1.Models.siniflar;
using System.Data.Entity;
namespace WebApplication1.Controllers
{
	public class AdminController : Controller
	{
		// GET: Admin
		Context c = new Context();
		[Authorize]
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
		// burada güncelleme yapmıyor çünkü boş olan id değerleri mevcut
		public ActionResult BlogGüncelle(Blog d)
		{
			var blg = c.Blogs.Find(d. ID); // ID'ye göre veriyi bul
			if (blg == null)
			{
				return RedirectToAction("Index"); // Eğer blog bulunamazsa, yönlendir
			}
			// Veriyi güncelle
			blg.Aciklama = d.Aciklama;
			blg.BlogImage = d.BlogImage;
			blg.Tarih = d.Tarih;
			blg.Baslik = d.Baslik;
			// EntityState.Modified ile veritabanı bağlamına değişiklikleri bildir
			c.Entry(blg).State = EntityState.Modified;
			c.SaveChanges(); // Değişiklikleri kaydet
			return RedirectToAction("Index");
		}
		public ActionResult YorumListesi()
		{
			var yorumlar = c.Yorumlars.ToList();
			return View(yorumlar);
		}
		public ActionResult YorumSil(int id)
		{
			var b = c.Yorumlars.Find(id); // id ye göre bul ve b ye ATA
			c.Yorumlars.Remove(b);
			c.SaveChanges();
			return RedirectToAction("YorumListesi");
		}
		public ActionResult YorumGetir(int id)
		{
			var yr = c.Yorumlars.Find(id); // id ye göre bul ve b ye ATA
			return View("YorumGet ir", yr);
		}
		public ActionResult  YorumGuncelle(Yorumlar y)
		{
			var yrm = c.Yorumlars.Find(y.ID); // id ye göre bul ve yrm ye ATA
			yrm.KullaniciAdi = y.KullaniciAdi;
			yrm.Mail  = y.Mail;
			yrm.Yorum = y.Yorum;
			c.SaveChanges();
			return RedirectToAction("YorumListesi");
		}
	}
}