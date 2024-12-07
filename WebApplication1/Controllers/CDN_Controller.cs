using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.siniflar;
namespace WebApplication1.Controllers
{
    public class CDN_Controller : Controller
    {

        Context c = new Context();
        Nedir by = new Nedir();

        // GET: API
        public ActionResult Index()
        {
            by.Nedirler = c.Nedir.ToList();
            var t = c.Nedir.ToList();
            return View(t);
        }

        public ActionResult nedir()
        {
            var t = c.Nedir.ToList();
            return View(t);
        }
        public ActionResult NedirDetay(int id)
        {
            //var blogbul = c.Blogs.Where(x => x.ID == id).ToList();
            by.Nedirler = c.Nedir.Where(x => x.ID == id).ToList();

            return View(by);
        }
    }
}