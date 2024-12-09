using Hangfire;
using System;
using System.Globalization;
using System.Threading;
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

		public class BaseController : Controller
		{
			protected override void ExecuteCore()
			{
				string cultureName = RouteData.Values["lang"] as string ?? "tr"; // Varsayılan: Türkçe

				if (!string.IsNullOrEmpty(cultureName))
				{
					Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureName);
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);
				}

				base.ExecuteCore();
			}
		}
		public ActionResult ChangeLanguage(string lang)
		{
			if (!string.IsNullOrEmpty(lang))
			{
				HttpCookie langCookie = new HttpCookie("lang", lang);
				langCookie.Expires = DateTime.Now.AddYears(1);
				Response.Cookies.Add(langCookie);
			}
			return Redirect(Request.UrlReferrer.ToString());
		}

	}
}
