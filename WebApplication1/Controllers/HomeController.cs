using Hangfire;
using System;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Jobs;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			string imageUrl = "/web/images/glasss.png";
			// Dil bilgisi kontrolü (varsayılan olarak Türkçe'yi ayarlıyoruz)
			string lang = Session["lang"] as string ?? "tr"; // "tr" varsayılan dil olarak
			ViewBag.Language = lang;  // Dil bilgisini View'a taşıyoruz
			return View();
		}
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";
			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";
			return View();
		}
		public ActionResult TriggerJob()
		{
			// Hangfire arka plan görevi
			BackgroundJob.Enqueue(() => Console.WriteLine($"Şu anki saat: {DateTime.Now}"));

			return Json(new { success = true, message = "Görev tetiklendi ve saat konsola yazıldı." });
		}

		public ActionResult ChangeLanguage(string lang)
		{
			// Eğer lang parametresi null veya boş ise, varsayılan olarak Türkçe'yi seçiyoruz
			if (string.IsNullOrEmpty(lang))
			{
				lang = "tr"; // Türkçe'yi varsayılan dil olarak ayarlıyoruz
			}

			// Session kontrolü ve dil bilgisinin saklanması
			if (Session != null)
			{
				Session["lang"] = lang; // Oturumda dil bilgisini saklayabilirsiniz
			}

			// UrlReferrer kontrolü yaparak, kullanıcıyı geri yönlendirme
			if (Request.UrlReferrer != null)
			{
				return Redirect(Request.UrlReferrer.ToString());  // Önceki sayfaya yönlendir
			}
			else
			{
				// Eğer UrlReferrer null ise, ana sayfaya yönlendirme yapılabilir
				return RedirectToAction("Index", "Home");  // Ana sayfaya yönlendir
			}
		}
	}
}
