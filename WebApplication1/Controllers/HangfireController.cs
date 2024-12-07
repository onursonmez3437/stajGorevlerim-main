using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HangfireController : Controller
    {
        // GET: Hangfire
        public ActionResult Index()
        {
            return View();
        }
    }

}