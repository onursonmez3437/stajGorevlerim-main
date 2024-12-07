using Hangfire;
using Owin;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;

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

		protected void Application_BeginRequest()
		{
			// Session nesnesi null olup olmadığını kontrol et
			if (HttpContext.Current.Session != null)
			{
				var lang = (string)HttpContext.Current.Session["lang"];
				if (lang != null)
				{
					System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(lang);
					System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
				}
			}
		}
	}
}
