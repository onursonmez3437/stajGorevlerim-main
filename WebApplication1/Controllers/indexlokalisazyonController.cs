using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class indexlokalisazyonController : Controller
    {
        // GET: indexlokalisazyon
        public ActionResult Index()
        {
            return View();
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
				return Redirect(Request.UrlReferrer.ToString());
			}
			else
			{
				// Eğer UrlReferrer null ise, ana sayfaya yönlendirme yapılabilir
				return RedirectToAction("Index", "Home");
			}
		}
	}
}