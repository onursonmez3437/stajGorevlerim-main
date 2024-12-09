using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "DefaultWithLang",
				url: "{lang}/{controller}/{action}/{id}",
				defaults: new { lang = "tr", controller = "Home", action = "Index", id = UrlParameter.Optional },
				constraints: new { lang = "tr|en" } // Sadece Türkçe ve İngilizce
			);

			// Dil parametresi olmadan gelen istekler için rota
			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { lang = "tr", controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}