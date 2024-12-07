using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.siniflar;

namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        public ActionResult Index()
        {
            Context c = new Context();
            return View();
        }
        public ActionResult About()
        {

            return View();
        }
        public ActionResult CV()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult EnCokBegendiklerim()
        {
            return PartialView();
        }
        public PartialViewResult PartialStajdaOgrendiklerim()
        {
            return PartialView();
        }
        public PartialViewResult Dusuncelerim()
        {
            return PartialView();
        }
    }
}