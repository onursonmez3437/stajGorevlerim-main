using Hangfire;
using Owin;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using WebApplication1;

namespace WebApplication1
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			// Hangfire için veritabanı bağlantısını yapılandırıyoruz
			GlobalConfiguration.Configuration
				.UseSqlServerStorage("Data Source=LAPTOP-EQAGSA07\\SQLEXPRESS;Initial Catalog=YourDatabaseName;Integrated Security=True;");


			// Varsayılan dil ayarları
			System.Globalization.CultureInfo.DefaultThreadCurrentCulture = new System.Globalization.CultureInfo("tr-TR");
			System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
		}

		public void Configuration(IAppBuilder app)
		{
			// Hangfire dashboard ve server yapılandırması
			app.UseHangfireDashboard("/hangfire"); // Hangfire Dashboard'a /hangfire yolu ile erişebilirsiniz
			app.UseHangfireServer();  // Hangfire server'ını başlatıyoruz

			// SignalR'ı aktif etmek için gerekli kodu ekliyoruz
			// Ancak Hangfire için MapHubs() kullanımı gerekli değildir
			// Çünkü Hangfire dashboard kendi SignalR yapılandırmasını yönetir
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			var lang = HttpContext.Current.Request.RequestContext.RouteData.Values["lang"]?.ToString();

			// Eğer dil parametresi yoksa, varsayılan olarak 'tr' dilini kullan
			if (string.IsNullOrEmpty(lang))
			{
				lang = "tr";
			}

			var currentUrl = HttpContext.Current.Request.RawUrl;

			// Eğer URL'nin başında dil parametresi yoksa, otomatik olarak ekle
			if (!currentUrl.StartsWith("/" + lang))
			{
				var newUrl = "/" + lang + currentUrl;
				HttpContext.Current.Response.Redirect(newUrl);
			}
		}
	}
}
