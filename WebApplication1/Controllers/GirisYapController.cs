using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models.siniflar;

namespace WebApplication1.Controllers
{
	public class GirisYapController : Controller
	{
		// GET: GirisYap
		Context c = new Context();
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Login(Admin ad)
		{
			var bilgiler = c.Admins.FirstOrDefault(x => x.Mail == ad.Mail && x.Konu == ad.Konu);
			if (bilgiler != null)
			{
				FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
				Session["Mail"] = bilgiler.Mail.ToString();
				return RedirectToAction("Index", "Admin");
			}
			else
			{
				return View();
			}
		}
		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Login", "GirisYap");
				}

	}
}